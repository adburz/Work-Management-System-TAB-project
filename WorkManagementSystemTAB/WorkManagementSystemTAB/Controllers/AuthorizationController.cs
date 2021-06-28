

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Configuration;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.DTO.Response;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Roles;
using WorkManagementSystemTAB.Services.Users;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IRolesRepository _rolesRepository;
        private readonly JwtConfig _jwtConfig;
        public AuthorizationController(IOptionsMonitor<JwtConfig> optionsMonitor,
            IUsersService usersService, IRolesRepository rolesRepository)
        {
            _usersService = usersService;

            _rolesRepository = rolesRepository;

            _jwtConfig = optionsMonitor.CurrentValue;
        }

        private string GenerateJwtToken(User newUser)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            //!TODO
            //Add var claims = new List<Claim>();
            //foreach(role in user.Role.Accessibility) {claims.Add(new Claim(ClaimType.Role, role.title)}...
            //czy cos

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Login),
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Password),
                    //new Claim(ClaimTypes.Role, newUser.Role.Title),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
                var existingUser = _usersService.FindUserByEmail(user.Email);
                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Email already in use" },
                        Success = false
                    });
                }
                var newUser = new User() { Login = user.Email, Password = user.Password, RoleId = _rolesRepository.GetRoleIdByName(user.RoleName) };

                //var isCreated = 
                _usersService.Create(newUser, user.Password);

                var jwtToken = GenerateJwtToken(newUser);
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

        [HttpPost("api/[controller]/log")]
        public IActionResult Authorize(UserAuthorizationDTO user)
        {
            return null;
        }
    }


}
