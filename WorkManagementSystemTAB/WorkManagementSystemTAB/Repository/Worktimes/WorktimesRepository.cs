using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Worktimes
{
    public class WorktimesRepository : IWorktimesRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public WorktimesRepository(TABWorkManagementSystemContext context) => _context = context;
        public Worktime Add(Worktime entity)
        {
            _context.Worktimes.Add(entity);
            this.Save();
            return entity;
        }

        public void Delete(Guid id)
        {
            var worktimeToDelete = _context.Worktimes.FirstOrDefault(u => u.UserId == id);
            if (worktimeToDelete != null)
            { _context.Remove(worktimeToDelete); }
        }

        public IEnumerable<Worktime> GetAll()
        {
            return _context.Worktimes.ToList();
        }

        public Worktime GetById(Guid id)
        {
            return _context.Worktimes.Find(id);
        }

        public IEnumerable<Worktime> GetWorktimesByUserId(Guid userId)
        {
            return _context.Worktimes.Select(x => x)
                                     .Where(x => x.UserId == userId)
                                     .ToList();                 
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
