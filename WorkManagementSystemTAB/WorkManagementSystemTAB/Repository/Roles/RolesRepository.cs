using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;
using System.Linq;

namespace WorkManagementSystemTAB.Repository.Roles
{
    public class RolesRepository : IRolesRepository
    {
        private readonly TABWorkManagementSystemContext _context;
        public RolesRepository(TABWorkManagementSystemContext context) => _context = context;

        public Role Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public Role AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Role GetRoleByName(string name)
        {
           return _context.Roles.FirstOrDefault(x => x.Name == name);
        }

        public Guid GetRoleIdByName(string name)
        {
            return (Guid)(GetRoleByName(name)?.RoleId);
        }

        public string GetRoleNameById(Guid id)
        {

            return _context.Roles.FirstOrDefault(x => id.Equals(x.RoleId))?.Name;
        }
        public string GetAccessLvlById(Guid id)
        {
            return _context.Roles.FirstOrDefault(x => id.Equals(x.RoleId)).AccessLevel.ToString();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
