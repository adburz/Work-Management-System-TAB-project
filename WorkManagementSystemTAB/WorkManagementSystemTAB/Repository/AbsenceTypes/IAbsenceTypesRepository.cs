using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.AbsenceTypes
{
    public interface IAbsenceTypesRepository : IRepository<AbsenceType, Guid>
    {
        public AbsenceType Update(AbsenceTypeUpdateDTO absenceType);
        public AbsenceType GetByName(string name);
    }
}
