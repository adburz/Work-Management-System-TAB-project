using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.DTO.Response;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Users
{
    public interface IUsersService
    {
        public IEnumerable<UserResponse> GetUsers();
        public UserResponse GetById(Guid id);
        public User AddUser(AddUserDTO user);
        public UserResponse GetUserByEmail(string email);
        public void DeleteUser(Guid id);
        public User Update(UserUpdateDTO user);
        public User CutDaysOff(Guid id, int daysToCut);
        public bool IsAuthor(Guid userId, string email);
        public User GetFullUserByEmail(string email);
    }
}
