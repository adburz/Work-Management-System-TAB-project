using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Authorization
{
    public class AuthorizationRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public AuthorizationRepository(TABWorkManagementSystemContext context) => _context = context;

        public async Task<User> FindUserByEmailAsync(User user)
        {
            var foundedUser = _context.Users.FindAsync(user.Login);
            return await foundedUser;
        }
    }
}
