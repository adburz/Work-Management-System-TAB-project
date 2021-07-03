using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Absences;

namespace WorkManagementSystemTAB.Services.Absences
{
    public class AbsencesService : IAbsencesService
    {
        private readonly IAbsencesRepository _absencesRepository;
        public AbsencesService(IAbsencesRepository absencesRepository) {
            _absencesRepository = absencesRepository;
        }

        public Absence Add(AbsenceDTO entity)
        {
            //var newAbssence = new Absence()
            //{
            //    AbsenceId = Guid.NewGuid(),

            //};
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Absence> GetAll()
        {
            throw new NotImplementedException();
        }

        public Absence GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
