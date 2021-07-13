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
        public UserDTO GetById(Guid id);
        public User AddUser(AddUserDTO user);
        public UserDTO GetUserByEmail(string email);
        public void DeleteUser(Guid id);
        public User Update(User user);
        public User CutDaysOff(Guid id, int daysToCut);
        public bool IsAuthor(Guid userId, string email);
    }
}
