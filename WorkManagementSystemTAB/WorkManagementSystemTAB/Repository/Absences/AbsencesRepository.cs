using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Absences
{
    public class AbsencesRepository : IAbsencesRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public AbsencesRepository(TABWorkManagementSystemContext context) => _context = context;

        public Absence Add(Absence entity)
        {
            throw new NotImplementedException();
        }

        public Absence AddAsync(Absence entity)
        {
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

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
