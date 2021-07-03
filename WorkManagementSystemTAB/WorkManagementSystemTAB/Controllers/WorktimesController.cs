using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult GetUsersWorktimeSchedule(string email)
        {
            var schedule = _worktimesService.GetUsersWorktimeSchedule(email);
            return (schedule == null) ? Ok(schedule) : BadRequest("User has not any worktime blocks planned or does not exist.");
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
            return (newWorktime==null) ? Ok(newWorktime): BadRequest("Worktime you are trying to add is overlapping with user's worktime schedule.");
        }
        [HttpDelete("delete/{id}")]
        public void Delete(Guid id)
        {
            _worktimesService.Delete(id);
        }
    }
}
