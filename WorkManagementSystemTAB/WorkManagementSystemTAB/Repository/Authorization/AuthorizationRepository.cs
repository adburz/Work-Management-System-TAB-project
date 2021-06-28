using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Authorization
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public AuthorizationRepository(TABWorkManagementSystemContext context) => _context = context;

        public User FindUserByEmail(string email)
        {
            var foundUser = _context.Users.FirstOrDefault(x=> x.Login == email);
            return foundUser;
        }
    }
}
