using System;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Authorization
{
    public interface IAuthorizationRepository 
    {
        public User GetUserByEmail(string email);
    }
}
