using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.UserResitory;

namespace WorkManagementSystemTAB.UsersData
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        public UsersService(IUsersRepository userRepository) {
            _userRepository = userRepository;
        }


        #region Methods
        public User AddUser(User user) {
            return _userRepository.Add(user);
        }

        public void DeleteUser() {
            throw new NotImplementedException();
        }

        public User GetUser(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers() {
            return _userRepository.GetAll();
        }
        #endregion
    }
}
