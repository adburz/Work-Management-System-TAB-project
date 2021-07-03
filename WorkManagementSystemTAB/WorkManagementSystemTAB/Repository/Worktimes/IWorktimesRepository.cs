using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Worktimes
{
    public interface IWorktimesRepository : IRepository<Worktime, Guid>
    {
        public List<Worktime> GetWorktimesByUserId(Guid userId);
    }
}
