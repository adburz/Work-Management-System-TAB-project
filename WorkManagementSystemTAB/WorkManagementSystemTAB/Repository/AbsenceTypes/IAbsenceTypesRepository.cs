using System;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.AbsenceTypes
{
    public interface IAbsenceTypesRepository : IRepository<AbsenceType, Guid>
    {
        public AbsenceType Update(AbsenceType absenceType);
        public AbsenceType GetByName(string name);
    }
}
