using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Absences;
using WorkManagementSystemTAB.Repository.AbsenceTypes;
using WorkManagementSystemTAB.Repository.UserResitory;

namespace WorkManagementSystemTAB.Services.Absences
{
    public class AbsencesService : IAbsencesService
    {
        private readonly IAbsencesRepository _absencesRepository;
        private readonly IAbsenceTypesRepository _absencesTypesRepository;
        private readonly IUsersRepository _usersRepository;

        public AbsencesService(IAbsencesRepository absencesRepository, IAbsenceTypesRepository absencesTypesRepository, IUsersRepository usersRepository)
        {
            _absencesRepository = absencesRepository;
            _absencesTypesRepository = absencesTypesRepository;
            _usersRepository = usersRepository;
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

        public Absence Modify(Absence absence)
        {
            return _absencesRepository.Modify(absence);
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

        public IEnumerable<Absence> GetAllWorkerAbsensces(Guid id)
        {
            var allAbsences = GetAll();

            return allAbsences.Where(x => x.UserId == id).ToList();
        }

        public IEnumerable<Absence> GetAll()
        {
            return _absencesRepository.GetAll();
        }

        public Absence GetById(Guid id)
        {
            return _absencesRepository.GetById(id);
        }

        public bool IsAuthor(Absence absence, string email)
        {

            var user = _usersRepository.GetUserByEmail(email);
            if (user == null)
                return false;

            return user.UserId == absence.UserId;

        }

        public IEnumerable<Absence> GetAllActive()
        {
            return _absencesRepository.GetAll().Where(x => x.Confirmed == false).ToList();
        }

        public IEnumerable<Absence> GetAllActiveWorkerAbsences(Guid id)
        {
            return GetAllActive().Where(x => x.UserId == id).ToList();
        }

        public IEnumerable<Absence> GetAllConfirmed()
        {
            return _absencesRepository.GetAll().Where(x => x.Confirmed == true).ToList();
        }
        
        public IEnumerable<Absence> GetAllConfirmedeWorkerAbsences(Guid id)
        {
            return GetAllConfirmed().Where(x => x.UserId == id).ToList();
        }

    }
}
