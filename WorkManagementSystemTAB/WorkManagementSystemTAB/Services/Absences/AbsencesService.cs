using System;
using System.Collections.Generic;
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
            return _absencesRepository.Approve(id);
        }
        // if(absenceType.IfShorted)
        //    {
        //        var Duration = entity.EndDate - entity.StartDate;
        //var daysToCut = Duration.Days <= 0 ? 1 : Duration.Days;

        //_usersRepository.Modify(entity.UserId, daysToCut);
        //    }

        public void Delete(Guid id)
        {
            _absencesRepository.Delete(id);
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
    }
}
