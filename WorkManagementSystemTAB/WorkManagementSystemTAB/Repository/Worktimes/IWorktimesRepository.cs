using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Worktimes
{
    public interface IWorktimesRepository : IRepository<Worktime, Guid>
    {
        public IEnumerable<Worktime> GetWorktimesByUserId(Guid userId);
        public IEnumerable<Worktime> AddListOfWorktimes(IEnumerable<Worktime> worktimeList);
    }
}
