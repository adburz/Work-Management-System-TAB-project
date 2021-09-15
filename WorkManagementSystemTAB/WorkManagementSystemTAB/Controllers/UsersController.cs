using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Users;
using WorkManagementSystemTAB.DTO.Request;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    //[Authorize]
    [ApiController]
    public class UsersController : BaseAccessController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var users = _usersService.GetUsers();

            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            if (!_usersService.IsAuthor(id, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            var users = _usersService.GetById(id);

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

        [HttpPut]
        public IActionResult UpdateUser(UserUpdateDTO user)
        {
            if (!_usersService.IsAuthor(user.UserId, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            //if(IsWorker()) What is this?
            //{
            //    //worker cant change roles
            //    user.RoleId = Guid.Empty;
            //}

            user.Password = AuthorizationController.EncriptPassword(user.Password);
            var result = _usersService.Update(user);

            if(result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _usersService.GetById(id);

            if (result == null)
                return NotFound();

            _usersService.DeleteUser(id);

            return Ok(result);
        }


    }
}
