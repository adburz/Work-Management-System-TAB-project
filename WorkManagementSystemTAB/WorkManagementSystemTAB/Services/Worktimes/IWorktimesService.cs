using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Worktimes
{
    public interface IWorktimesService : IService<Worktime, Guid,WorktimeDTO>
    {
    }
}
