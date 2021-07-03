using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll() {
            var worktimes = _worktimesService.GetAll();
            return Ok(worktimes);
        }
        [HttpPost("addWorktime")]
        public IActionResult Add(WorktimeDTO worktime)
        {
            var newWorktime = _worktimesService.Add(worktime);
            if(newWorktime==null)
            {
                return BadRequest("Worktime you are trying to add is overlapping with user's worktime schedule.");
            }
            return Ok(newWorktime);
        }
    }
}
