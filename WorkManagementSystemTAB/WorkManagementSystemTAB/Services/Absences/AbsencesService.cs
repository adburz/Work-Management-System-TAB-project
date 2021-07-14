using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Absences;
using WorkManagementSystemTAB.Repository.AbsenceTypes;
using WorkManagementSystemTAB.Repository.UserResitory;
using WorkManagementSystemTAB.Services.Worktimes;

namespace WorkManagementSystemTAB.Services.Absences
{
    public class AbsencesService : IAbsencesService
    {
        private readonly IAbsencesRepository _absencesRepository;
        private readonly IAbsenceTypesRepository _absencesTypesRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IWorktimesService _worktimesService;

        public AbsencesService(IAbsencesRepository absencesRepository, IAbsenceTypesRepository absencesTypesRepository, IUsersRepository usersRepository, IWorktimesService worktimesService)
        {
            _absencesRepository = absencesRepository;
            _absencesTypesRepository = absencesTypesRepository;
            _usersRepository = usersRepository;
            _worktimesService = worktimesService;
        }

        public Absence Add(AbsenceDTO absenceDTO)
        {
            var newAbssence = new Absence()
            {
                UserId = absenceDTO.UserId,
                AbsenceId = Guid.NewGuid(),
                AbsenceTypeId = absenceDTO.AbsenceTypeId,
                Confirmed = false,
                StartDate = absenceDTO.StartDate,
                EndDate = absenceDTO.EndDate
            };

            if ((newAbssence.EndDate - newAbssence.StartDate).Minutes < 0)
            {
                var tmp = newAbssence.EndDate;
                newAbssence.EndDate = newAbssence.StartDate;
                newAbssence.StartDate = tmp;
            }

            var absenceType = _absencesTypesRepository.GetById(absenceDTO.AbsenceTypeId);

            if (absenceType == null)
                return null;

            if (absenceType.Name == "on-demand" || absenceType.Name == "maternity")
                newAbssence.Confirmed = true;

            _absencesRepository.Add(newAbssence);
            return newAbssence;
        }

        public Absence Update(AbsenceUpdateDTO absence)
        {
            return _absencesRepository.Update(absence);
        }

        public Absence Approve(Guid id)
        {
            var absence = _absencesRepository.Approve(id);

            if (absence == null)
                return null;

            var absenceType = _absencesTypesRepository.GetById(absence.AbsenceTypeId);

            if ((bool)(absenceType?.IfShorted))
            {
                var Duration = absence.EndDate - absence.StartDate;
                var daysToCut = Duration.Days <= 0 ? 1 : Duration.Days;

                var user = _usersRepository.CutDaysOff(absence.UserId, daysToCut);

                if (user == null) //error in base absence has wrong user bound to it 
                    return null;

            }

            return absence;
        }


        public void Delete(Guid id)
        {
            _absencesRepository.Delete(id);
        }

        public IEnumerable<Absence> GetAllWorkerAbsensces(Guid userId)
        {
            var allAbsences = GetAll();

            return allAbsences.Where(x => x.UserId == userId).ToList();
        }

        public IEnumerable<Absence> GetAll()
        {
            return _absencesRepository.GetAll();
        }

        public Absence GetById(Guid id)
        {
            return _absencesRepository.GetById(id);
        }

        public bool IsAuthor(Guid userId, string email)
        {
            var user = _usersRepository.GetUserByEmail(email);
            if (user == null)
                return false;

            return user.UserId == userId;
        }

        public IEnumerable<Absence> GetAllActive()
        {
            return _absencesRepository.GetAll().Where(x => x.Confirmed == false).ToList();
        }

        public IEnumerable<Absence> GetAllActiveWorkerAbsences(Guid userId)
        {
            return GetAllActive().Where(x => x.UserId == userId).ToList();
        }

        public IEnumerable<Absence> GetAllConfirmed()
        {
            return _absencesRepository.GetAll().Where(x => x.Confirmed == true).ToList();
        }

        public IEnumerable<Absence> GetAllConfirmedeWorkerAbsences(Guid userId)
        {
            return GetAllConfirmed().Where(x => x.UserId == userId).ToList();
        }

        public IEnumerable<IEnumerable<WorktimeDTO>> FindReplacment(Guid absenceId)
        {
            var emptyList = new List<List<WorktimeDTO>>() { new List<WorktimeDTO>() };
            var absence = _absencesRepository.GetById(absenceId);

            if (absence == null)
                return null;

            var allWorktimes = _worktimesService.GetAll();
            var allUsers = _usersRepository.GetAll();
            var applicant = _usersRepository.GetById(absence.UserId);

            if (allWorktimes == null || allUsers == null || applicant == null)
                return emptyList;

            var usersWithSameRoleWihtoutApplicant = allUsers?.Where(x => x.RoleId == applicant.RoleId && x.UserId != absence.UserId)?.ToList();

            if (usersWithSameRoleWihtoutApplicant?.Count == 0)
                return emptyList;

            var allWorktimesWithoutAplicantWithSameRole = allWorktimes.Join(usersWithSameRoleWihtoutApplicant,
                                                                            worktime => worktime.UserId,
                                                                            user => user.UserId,
                                                                            (worktime, user) => worktime);

            var applicantWorktimes = _worktimesService.GetUsersWorktimeSchedule(absence.UserId);
            var afflictedWorktimes = applicantWorktimes?.Where(x => absence.StartDate <= x.EndTime && absence.EndDate >= x.StartTime)?.ToList();

            if (afflictedWorktimes == null)
                return emptyList;

            var replacementWorktimes = new List<List<WorktimeDTO>>();

            afflictedWorktimes.ForEach(afflictedWorktime =>
            {
                List<WorktimeDTO> tmpListForEachWorktime = new();
                usersWithSameRoleWihtoutApplicant.ForEach(user =>
                {
                    var userWorktimes = allWorktimesWithoutAplicantWithSameRole.Where(x => x.UserId == user.UserId).ToList();

                    if (userWorktimes.TrueForAll(x => x.StartTime > afflictedWorktime.EndTime || x.EndTime < afflictedWorktime.StartTime))
                    {
                        var tmpWorktime = new WorktimeDTO()
                        {
                            StartTime = afflictedWorktime.StartTime,
                            EndTime = afflictedWorktime.EndTime,
                            UserId = user.UserId,
                        };
                        tmpListForEachWorktime.Add(tmpWorktime);
                    }
                });
                replacementWorktimes.Add(tmpListForEachWorktime);
            });

            return replacementWorktimes;
        }

        
    }
}
