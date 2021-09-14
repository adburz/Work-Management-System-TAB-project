using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Worktimes
{
    public interface IWorktimesService : IService<Worktime, Guid,DTO.Request.WorktimeDTO>
    {
        public IEnumerable<Worktime> GetUsersWorktimeSchedule(Guid userId);
        public IEnumerable<Worktime> AddWorktimeList(IEnumerable<DTO.Request.WorktimeDTO> worktimeList);
        public Worktime Update(WorktimeUpdateDTO worktime);
    }
}
