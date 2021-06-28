using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.AbsenceTypes;

namespace WorkManagementSystemTAB.Services.AbsenceTypes
{
    public class AbsencesTypesService : IAbsenceTypesService
    {
        private readonly IAbsenceTypesRepository _absencesRepository;
        public AbsencesTypesService(IAbsenceTypesRepository absencesRepository) {
            _absencesRepository = absencesRepository;
        }

        public AbsenceType Add(AbsenceType entity) {
            throw new NotImplementedException();
        }

        public void Delete(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<AbsenceType> GetAll() {
            throw new NotImplementedException();
        }

        public AbsenceType GetById(Guid id) {
            throw new NotImplementedException();
        }
    }
}
