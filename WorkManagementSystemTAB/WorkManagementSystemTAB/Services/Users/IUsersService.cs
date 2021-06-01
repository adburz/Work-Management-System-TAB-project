using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Users
{
    public interface IUsersService
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(Guid id);
        public User Create(User user, string password);
        public Task<User> FindUserByEmailAsync(string email);
        public void DeleteUser();

    }
}
