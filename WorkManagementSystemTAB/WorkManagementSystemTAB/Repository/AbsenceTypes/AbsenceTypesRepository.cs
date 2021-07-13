using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.AbsenceTypes
{
    public class AbsenceTypesRepository : BaseRepository, IAbsenceTypesRepository
    {

        public AbsenceTypesRepository(TABWorkManagementSystemContext context) : base(context) { }

        public AbsenceType Add(AbsenceType enity)
        {
            var dataBaseItem = _context.AbsenceTypes.FirstOrDefault(x => x.AbsenceTypeId == enity.AbsenceTypeId);

            if (dataBaseItem == null)
            {
                _context.AbsenceTypes.Add(enity);
                Save();
            }
            return (enity);
        }

        public void Delete(Guid id)
        {
            var absenceType = _context.AbsenceTypes.FirstOrDefault(x => x.AbsenceTypeId == id);
            if (absenceType != null)
            {
                _context.AbsenceTypes.Remove(absenceType);
                Save();
            }
        }

        public AbsenceType Update(AbsenceType absenceType)
        {
            var foundAbsenceType = _context.AbsenceTypes.FirstOrDefault(x => x.AbsenceTypeId == absenceType.AbsenceTypeId);

            if (foundAbsenceType == null)
                return null;

            if (!string.IsNullOrEmpty(absenceType.Name))
                foundAbsenceType.Name = absenceType.Name;

            foundAbsenceType.IfShorted = absenceType.IfShorted;

            Save();
            return foundAbsenceType;
        }

        public IEnumerable<AbsenceType> GetAll()
        {
            return _context.AbsenceTypes.ToList();
        }

        public AbsenceType GetById(Guid id)
        {
            return _context.AbsenceTypes.FirstOrDefault(x => x.AbsenceTypeId == id);
        }

        public AbsenceType GetByName(string name)
        {
            return _context.AbsenceTypes.FirstOrDefault(x => x.Name == name);
        }

    }
}
