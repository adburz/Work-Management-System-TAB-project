﻿using System;
using System.Collections.Generic;

using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Worktimes
{
    public interface IWorktimesService : IService<Worktime, Guid,DTO.Request.WorktimeDTO>
    {
        public IEnumerable<DTO.Response.WorktimeDTO> GetUsersWorktimeSchedule(Guid userId);
        public IEnumerable<Worktime> AddWorktimeList(IEnumerable<DTO.Request.WorktimeDTO> worktimeList);
        public Worktime UpdateWorktime(Worktime worktime);
    }
}
