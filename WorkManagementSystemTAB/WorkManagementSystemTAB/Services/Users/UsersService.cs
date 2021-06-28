using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.UserResitory;

namespace WorkManagementSystemTAB.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }


        #region Methods
        public User Create(User user, string password)
        {
            user.Password = password;
            return _userRepository.Add(user);
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public User FindUserByEmail(string email)
        {
            return _userRepository.FindUserByEmail(email);
        }

        public User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }
        #endregion
    }
}
