using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.UserResitory
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
        public User GetUserByEmail(string email);
        public User Update(UserUpdateDTO user);
        public User CutDaysOff(Guid id, int daysToCut);
    }
}
