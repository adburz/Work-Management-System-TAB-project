using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.UsersData
{
    public interface IUsersService
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        User AddUser(User user);
        void DeleteUser();

    }
}
