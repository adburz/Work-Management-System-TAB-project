using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Worktimes;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class WorktimesController : BaseAccessController
    {
        private readonly IWorktimesService _worktimesService;
        public WorktimesController(IWorktimesService worktimesService)
        {
            _worktimesService = worktimesService;
        }

        [HttpGet("{worktimeId}")]
        public IActionResult GetWorktime(Guid worktimeId)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _worktimesService.GetById(worktimeId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUsersWorktimeSchedule(Guid userId)
        {
            var schedule = _worktimesService.GetUsersWorktimeSchedule(userId);
            return schedule.Any() ? Ok(schedule) : BadRequest("User has not any worktime blocks planned or does not exist.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var worktimes = _worktimesService.GetAll();
            return Ok(worktimes);
        }

        [HttpPost]
        public IActionResult Add(WorktimeDTO worktime)
        {
            var newWorktime = _worktimesService.Add(worktime);
            return newWorktime == null ? BadRequest("Worktime you are trying to add is overlapping with user's worktime schedule.") : Ok(newWorktime);
        }

        [HttpPost("addWorktimeList")]
        public IActionResult AddWorktimeList(IEnumerable<WorktimeDTO> worktimeList)
        {
            var newWorktimes = _worktimesService.AddWorktimeList(worktimeList);
            return newWorktimes == null ? BadRequest("One or more worktimes you are trying to add are overlapping with user's worktime schedule" +
                "or worktimes you are trying to add are overlapping with each other.") :
                Ok(newWorktimes);
        }

        [HttpPut]
        public IActionResult UpdateWorktime(WorktimeUpdateDTO worktime)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _worktimesService.GetById(worktime.WorktimeId);

            if (result == null)
                return NotFound();

            return Ok(_worktimesService.UpdateWorktime(worktime));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _worktimesService.GetById(id);
            
            if (result == null)
                return NotFound();

            _worktimesService.Delete(id);

            return Ok(result);
        }
    }
}
