﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Users;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]/")]
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
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            
            var users = _usersService.GetUsers();
            return Ok(users);
        }

        [HttpPost("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var users = _usersService.GetUser(id);
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound($"User with id {id} was not found.");
        }

        //TODO UserDTO should be used over there.
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddUser(User user)
        {
            var result = _usersService.Create(user, user.Password);
            return Ok(result);
        }
    }
}
