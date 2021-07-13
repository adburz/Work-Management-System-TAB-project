﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkManagementSystemTAB.Configuration;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.DTO.Response;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Authorization;
using WorkManagementSystemTAB.Services.Roles;
using WorkManagementSystemTAB.Services.Users;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : BaseAccessController
    {

        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;
        private readonly IAuthService _authService;

        private readonly JwtConfig _jwtConfig;
        public AuthorizationController(IOptionsMonitor<JwtConfig> optionsMonitor,
            IRolesService rolesService, IAuthService authService, IUsersService usersService)
        {
            _rolesService = rolesService;

            _jwtConfig = optionsMonitor.CurrentValue;

            _authService = authService;

            _usersService = usersService;
        }

        private string GenerateJwtToken(User user)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(Strings.AccessLevel,_rolesService.GetAccessLvlById(user.RoleId))
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationDTO user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _usersService.GetUserByEmail(user.Email);
                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Email already in use" },
                        Success = false
                    });
                }

                var result = _usersService.AddUser(new AddUserDTO { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Password = EncriptPassword(user.Password) });

                if (result == null)
                    return BadRequest();

                var jwtToken = GenerateJwtToken(new User()
                {
                    Email = user.Email,
                    Password = EncriptPassword(user.Password),
                    RoleId = _rolesService.GetRoleIdByName(Strings.UnAssigned)
                });
                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Success = false
            });
        }

        [HttpPost("login")]
        public IActionResult Authorize(UserAuthorizationDTO user)
        {

            user.Password = EncriptPassword(user.Password);

            var foundUser = _usersService.GetFullUserByEmail(user.Email);
            
            if (foundUser == null)
                return NotFound();


            if (foundUser.Password == user.Password)
                return Ok(GenerateJwtToken(foundUser));

            return NotFound();
        }

        //TODO
        private string EncriptPassword(string password)
        {
            return password;
        }
    }


}
