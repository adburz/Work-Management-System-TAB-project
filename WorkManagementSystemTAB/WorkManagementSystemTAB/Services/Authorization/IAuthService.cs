using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Authorization
{
    public interface IAuthService
    {
        User GetUser(UserAuthorizationDTO user);

    }
}
