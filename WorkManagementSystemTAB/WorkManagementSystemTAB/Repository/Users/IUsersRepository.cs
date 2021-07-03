using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.UserResitory
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
        public User FindUserByEmail(string email);
        public User Modify(User user);
        public User Modify(Guid id, int daysToCut);
    }
}
