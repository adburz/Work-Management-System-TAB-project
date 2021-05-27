using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Worktimes;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]")]
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
    }
}
