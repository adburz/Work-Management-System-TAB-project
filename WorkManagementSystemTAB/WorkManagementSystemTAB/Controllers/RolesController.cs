using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Roles;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]")]
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
            string userId = User.FindFirst(ClaimTypes.Email)?.Value;
            var email = User.FindFirst(ClaimTypes.Name)?.Value;
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userssId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            return Ok(roles);
        }
    }
}
