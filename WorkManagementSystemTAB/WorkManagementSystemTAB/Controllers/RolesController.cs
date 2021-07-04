using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Roles;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [Authorize]
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
