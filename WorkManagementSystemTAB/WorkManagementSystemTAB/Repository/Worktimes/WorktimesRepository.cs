using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Worktimes
{
    public class WorktimesRepository : IWorktimesRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public WorktimesRepository(TABWorkManagementSystemContext context) => _context = context;
        public Worktime Add(Worktime entity)
        {
            throw new NotImplementedException();
        }

        public Worktime AddAsync(Worktime entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Worktime> GetAll()
        {
            throw new NotImplementedException();
        }

        public Worktime GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
