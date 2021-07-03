using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.DTO.Response;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Users
{
    public interface IUsersService
    {
        public IEnumerable<UserDTO> GetUsers();
        public UserDTO GetUser(Guid id);
        public User AddUser(AddUserDTO user);
        public UserDTO FindUserByEmail(string email);
        public void DeleteUser(Guid id);
        public User Modify(User user);
        public User Modify(Guid id, int daysToCut);

    }
}
