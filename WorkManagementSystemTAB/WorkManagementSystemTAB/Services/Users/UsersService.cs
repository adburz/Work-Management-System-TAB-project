using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.UserResitory;
using WorkManagementSystemTAB.DTO.Response;

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
        public User Create(User user)
        {
            return _userRepository.Add(user);
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }

        public UserDTO FindUserByEmail(string email)
        {
            var user = _userRepository.FindUserByEmail(email);
            return new UserDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                UserId = user.UserId,
                VacationDaysCount = user.VacationDaysCount
            };
        }

        public UserDTO GetUser(Guid id)
        {
            var user = _userRepository.GetById(id);
            return new UserDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                UserId = user.UserId,
                VacationDaysCount = user.VacationDaysCount
            };
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var usersList= _userRepository.GetAll();
            return usersList.Select(x => new UserDTO()
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RoleId = x.RoleId,
                UserId = x.UserId,
                VacationDaysCount = x.VacationDaysCount
            }
            ).ToList();
        }
        #endregion
    }
}
