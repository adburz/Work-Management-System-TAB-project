using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Roles;

namespace WorkManagementSystemTAB.Services.Roles
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesService(IRolesRepository rolesRepository) {
            _rolesRepository = rolesRepository;
        }
        public Role Add(Role entity) {
            throw new NotImplementedException();
        }

        public void Delete(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll() {
            throw new NotImplementedException();
        }

        public Role GetById(Guid id) {
            throw new NotImplementedException();
        }
    }
}
