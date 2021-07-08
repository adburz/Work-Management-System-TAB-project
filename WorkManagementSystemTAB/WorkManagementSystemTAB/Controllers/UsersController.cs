using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Users;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var xd = this.User.FindFirstValue(Strings.AccessLevel);

            if (xd == AccessLevelEnum.Worker.ToString())
                return BadRequest();

            var users = _usersService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var users = _usersService.GetUser(id);
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound($"User with id {id} was not found.");
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDTO user)
        {
            var result = _usersService.AddUser(user);
            if(result==null)
            {
                return BadRequest($"User with email: {user.Email} already exists.");
            }
            return Ok(result);
        }
    }
}
