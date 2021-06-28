using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.AbsenceTypes
{
    public class AbsenceTypesRepository : IAbsenceTypesRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public AbsenceTypesRepository(TABWorkManagementSystemContext context) => _context = context;

        public AbsenceType Add(AbsenceType entity)
        {
            throw new NotImplementedException();
        }

        public AbsenceType AddAsync(AbsenceType entity)
        {
            throw new NotImplementedException();
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

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
