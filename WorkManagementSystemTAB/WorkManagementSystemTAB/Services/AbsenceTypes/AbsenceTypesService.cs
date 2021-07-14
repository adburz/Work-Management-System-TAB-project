using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.AbsenceTypes;

namespace WorkManagementSystemTAB.Services.AbsenceTypes
{
    public class AbsenceTypesService : IAbsenceTypesService
    {
        private readonly IAbsenceTypesRepository _absencesRepository;
        public AbsenceTypesService(IAbsenceTypesRepository absencesRepository) {
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

        public AbsenceType Update(AbsenceTypeUpdateDTO absenceType)
        {
            return _absencesRepository.Update(absenceType);

        }
        public void Delete(Guid id)
        {
            _absencesRepository.Delete(id);
        }

        public IEnumerable<AbsenceType> GetAll()
        {
            return _absencesRepository.GetAll();
        }

        public AbsenceType GetById(Guid id)
        {
            return _absencesRepository.GetById(id);
        }

        public AbsenceType GetByName(string name)
        {
            return _absencesRepository.GetByName(name);
        }
    }
}
