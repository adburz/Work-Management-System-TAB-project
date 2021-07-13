using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Worktimes
{
    public class WorktimesRepository : BaseRepository,IWorktimesRepository
    {
        public WorktimesRepository(TABWorkManagementSystemContext context) : base(context) { }
        public Worktime Add(Worktime entity)
        {
            _context.Worktimes.Add(entity);
            this.Save();
            return entity;
        }

        public IEnumerable<Worktime> AddListOfWorktimes(IEnumerable<Worktime> worktimeList)
        {
            _context.Worktimes.AddRange(worktimeList);
            this.Save();
            return worktimeList;
        }

        public void Delete(Guid id)
        {
            var worktimeToDelete = _context.Worktimes.FirstOrDefault(w => w.WorktimeId==id);
            if (worktimeToDelete != null) _context.Remove(worktimeToDelete);
            this.Save();
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

        public Worktime UpdateWorktime(Worktime worktime)
        {
            if (worktime == null)
                return null;

            var foundWorktime = _context.Worktimes.FirstOrDefault(x => x.WorktimeId == worktime.WorktimeId);

            if (foundWorktime == null)
                return null;

            if (worktime.StartTime != DateTime.MinValue)
                foundWorktime.StartTime = worktime.StartTime;

            if (worktime.EndTime != DateTime.MinValue)
                foundWorktime.EndTime = worktime.EndTime;

            if (worktime.UserId != Guid.Empty)
                foundWorktime.UserId = worktime.UserId;

            Save();
            return foundWorktime;
        }
    }
}
