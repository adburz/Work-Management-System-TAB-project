using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.AbsenceTypes
{
    public interface IAbsenceTypesService  : IService<AbsenceType,Guid, AbsenceTypeDTO>
    {
        public AbsenceType Update(AbsenceTypeUpdateDTO absenceType);
        public AbsenceType GetByName(string name);
    }

}
