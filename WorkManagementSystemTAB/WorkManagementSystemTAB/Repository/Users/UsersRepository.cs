using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.UserResitory
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {

        public UsersRepository(TABWorkManagementSystemContext context) : base(context) { }

        public void Delete(Guid id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (userToDelete != null)
            { _context.Remove(userToDelete); }
            this.Save();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User Add(User entity)
        {
            _context.Users.Add(entity);
            this.Save();
            return entity;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User Update(User user)
        {
            var foundUser = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);

            if (foundUser == null)
                return null;

            if (!string.IsNullOrEmpty(user.Password))
                foundUser.Password = user.Password;

            if (!string.IsNullOrEmpty(user.Email))
                foundUser.Email = user.Email;

            if (!string.IsNullOrEmpty(user.FirstName))
                foundUser.FirstName = user.FirstName;

            if (!string.IsNullOrEmpty(user.LastName))
                foundUser.LastName = user.LastName;

            if (user.RoleId != Guid.Empty)
                foundUser.RoleId = user.RoleId;

            foundUser.VacationDaysCount = user.VacationDaysCount;

            Save();

            return foundUser;

        }

        public User CutDaysOff(Guid id, int daysToCut)
        {
            var foundUser = GetById(id);

            if (foundUser == null)
                return null;

            foundUser.VacationDaysCount -= daysToCut;

            Save();

            return foundUser;
        }
    }

}
