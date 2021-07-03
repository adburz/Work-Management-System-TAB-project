using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Authorization;

namespace WorkManagementSystemTAB.Services.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly IAuthorizationRepository _userRepository;

        public AuthService(IAuthorizationRepository userRepository)
        {
            _userRepository = userRepository;
        }

      
        User IAuthService.GetUser(UserAuthorizationDTO user)
        {
            return _userRepository.GetUserByEmail(user.Email);
        }
    }
}
