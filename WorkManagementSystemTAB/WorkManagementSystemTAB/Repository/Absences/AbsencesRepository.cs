using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Absences
{
    public class AbsencesRepository : BaseRepository, IAbsencesRepository
    {

        public AbsencesRepository(TABWorkManagementSystemContext context) :base(context) {}

        public Absence Add(Absence absence)
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
    }
}
