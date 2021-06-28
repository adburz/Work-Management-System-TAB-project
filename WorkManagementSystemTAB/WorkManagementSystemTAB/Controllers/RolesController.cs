using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Roles;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService) {
            _rolesService = rolesService;
        }

        [HttpGet]
        public IActionResult GetRoles() {
            var roles = _rolesService.GetAll();
            return Ok(roles);
        }
    }
}
