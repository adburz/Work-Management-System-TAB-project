using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Authorization
{
    public class AuthorizationRepository :BaseRepository, IAuthorizationRepository
    {

        public AuthorizationRepository(TABWorkManagementSystemContext context) : base(context) { }

        public User FindUserByEmail(string email)
        {
            var foundUser = _context.Users.FirstOrDefault(x=> x.Email == email);
            return foundUser;
        }
    }
}
