using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;

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
            throw new NotImplementedException();
        }

        public Role GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
