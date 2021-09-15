using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.UserResitory;
using WorkManagementSystemTAB.DTO.Response;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Repository.Roles;
using WorkManagementSystemTAB.Controllers;

namespace WorkManagementSystemTAB.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;
        public UsersService(IUsersRepository userRepository, IRolesRepository rolesRepository)
        {
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
        }
        #region Methods
        public User AddUser(AddUserDTO user)
        {
            if (_userRepository.GetUserByEmail(user.Email) != null)
            {
                return null;
            }

            var newUser = new User()
            {
                Email = user.Email,
                Password = AuthorizationController.EncriptPassword(user.Password),
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
            };

            return _userRepository.Add(newUser);
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }

        public UserResponse GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
           
            if (user == null)
                return null;

            return new UserResponse()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                UserId = user.UserId,
                VacationDaysCount = user.VacationDaysCount
            };
        }

        public UserResponse GetById(Guid id)
        {
            var user = _userRepository.GetById(id);
            
            if (user == null)
                return null;

            return new UserResponse()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                UserId = user.UserId,
                VacationDaysCount = user.VacationDaysCount
            };
        }

        public IEnumerable<UserResponse> GetUsers()
        {
            var usersList= _userRepository.GetAll();
            return usersList.Select(x => new UserResponse()
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


        public User Update(UserUpdateDTO user)
        {
            return _userRepository.Update(user);
        }

        public User CutDaysOff(Guid id, int daysToCut)
        {
            return _userRepository.CutDaysOff(id, daysToCut);
        }

        public bool IsAuthor(Guid userId, string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
                return false;

            return user.UserId == userId;
        }

        public User GetFullUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return _userRepository.GetUserByEmail(email);
        }
        #endregion
    }
}
