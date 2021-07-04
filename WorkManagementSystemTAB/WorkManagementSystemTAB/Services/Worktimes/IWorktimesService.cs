using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.DTO.Response;

using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Worktimes
{
    public interface IWorktimesService : IService<Worktime, Guid,DTO.Request.WorktimeDTO>
    {
        public IEnumerable<DTO.Response.WorktimeDTO> GetUsersWorktimeSchedule(Guid userId);
    }
}
