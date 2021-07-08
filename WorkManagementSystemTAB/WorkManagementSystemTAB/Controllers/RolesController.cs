using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Roles;
using System.Linq;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using System.Collections.Generic;

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

        [HttpGet("getAll")]
        public IActionResult GetRoles() {
            var roles = _rolesService.GetAll();
            return Ok(roles);
        }
        [HttpDelete]
        public IActionResult Delete(Guid roleId)
        {
            _rolesService.Delete(roleId);
            return Ok();
        }
        [HttpPost("add")]
        public IActionResult Add(RoleDTO role)
        {
            var newRole = _rolesService.Add(role);
            return newRole == null ? BadRequest("Role already exists.") : Ok(newRole);
        }
        [HttpPut]
        public IActionResult UpdateRole(Role role)
        {
            var updatedRole = _rolesService.UpdateRole(role);
            return updatedRole == null ? BadRequest("Role could not be updated.") : Ok(updatedRole);
        }
    }
}
