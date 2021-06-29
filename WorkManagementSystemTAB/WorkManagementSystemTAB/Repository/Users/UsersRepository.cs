using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.UserResitory
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public UsersRepository(TABWorkManagementSystemContext context) => _context = context;

        public void Delete(Guid id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (userToDelete != null)
            { _context.Remove(userToDelete); }
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

        public void Save()
        {
            _context.SaveChanges();
        }

        public User FindUserByEmail(string email)
        {
            return  _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User AddAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }

}
