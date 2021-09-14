using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Roles;
using System;
using Microsoft.AspNetCore.Authorization;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    //[Authorize]
    [ApiController]
    public class RolesController : BaseAccessController
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService) {
            _rolesService = rolesService;
        }

        [HttpGet]
        public IActionResult GetRoles() 
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var roles = _rolesService.GetAll();
            
            if (roles == null)
                return NotFound();

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _rolesService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(RoleDTO role)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var newRole = _rolesService.Add(role);

            return newRole == null ? BadRequest("Role already exists.") : Ok(newRole);
        }

        [HttpPut]
        public IActionResult UpdateRole(RoleUpdateDTO role)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var updatedRole = _rolesService.UpdateRole(role);
            
            return updatedRole == null ? BadRequest("Role could not be updated.") : Ok(updatedRole);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _rolesService.GetById(id);

            if (result == null)
                return NotFound();

            _rolesService.Delete(id);

            return Ok();
        }
    }
}
