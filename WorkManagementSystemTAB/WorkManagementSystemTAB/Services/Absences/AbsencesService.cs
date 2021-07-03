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

        public Absence Add(AbsenceDTO entity)
        {

            var newAbssence = new Absence()
            {
                UserId = entity.UserId,
                AbsenceId = Guid.NewGuid(),
                AbsenceTypeId = entity.AbsenceTypeId,
                Confirmed = false,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };

            var absenceType = _absencesTypesRepository.GetById(entity.AbsenceTypeId);

            if (absenceType.Name == "on-demand" || absenceType.Name == "maternity")
                newAbssence.Confirmed = true;


            _absencesRepository.Add(newAbssence);
            return newAbssence;




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
    }
}
