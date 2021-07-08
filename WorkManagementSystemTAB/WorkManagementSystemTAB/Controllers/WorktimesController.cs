using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Services.Worktimes;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class WorktimesController : ControllerBase
    {
        private readonly IWorktimesService _worktimesService;
        public WorktimesController(IWorktimesService worktimesService) {
            _worktimesService = worktimesService;
        }

        [HttpGet("getUsersWorktimes")]
        public IActionResult GetUsersWorktimeSchedule(Guid userId)
        {
            var schedule = _worktimesService.GetUsersWorktimeSchedule(userId);
            return schedule.Any() ? Ok(schedule) : BadRequest("User has not any worktime blocks planned or does not exist.");
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() {
            var worktimes = _worktimesService.GetAll();
            return Ok(worktimes);
        }
        [HttpPost("addWorktime")]
        public IActionResult Add(WorktimeDTO worktime)
        {
            var newWorktime = _worktimesService.Add(worktime);
            return newWorktime == null ? BadRequest("Worktime you are trying to add is overlapping with user's worktime schedule.") : Ok(newWorktime);
        }
        [HttpPost("addWorktimeList")]
        public IActionResult AddWorktimeList(IEnumerable<WorktimeDTO> worktimeList)
        {
            var newWorktimes = _worktimesService.AddWorktimeList(worktimeList);
            return newWorktimes==null ? BadRequest("One or more worktimes you are trying to add are overlapping with user's worktime schedule" +
                "or worktimes you are trying to add are overlapping with each other."):
                Ok(newWorktimes);

        }
        [HttpDelete("delete/{worktimeId}")]
        public void Delete(Guid worktimeId)
        {
            _worktimesService.Delete(worktimeId);
        }
    }
}
