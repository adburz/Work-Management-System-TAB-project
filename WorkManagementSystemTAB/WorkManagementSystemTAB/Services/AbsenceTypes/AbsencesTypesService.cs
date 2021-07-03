using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
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

        public AbsenceType Add(AbsenceTypeDTO absenceTypeDTO)
        {
            var newAbsenceType = new AbsenceType()
            {
                AbsenceTypeId = Guid.NewGuid(),
                Name = absenceTypeDTO.Name,
                IfShorted = absenceTypeDTO.IfShorted
            };

            return _absencesRepository.Add(newAbsenceType);
            
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AbsenceType> GetAll()
        {
            throw new NotImplementedException();
        }

        public AbsenceType GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
