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
        [HttpPost("add")]
        public IActionResult Add([FromBody]WorktimeDTO worktimeDTO)
        {
            return Ok();
        }
    }
}
