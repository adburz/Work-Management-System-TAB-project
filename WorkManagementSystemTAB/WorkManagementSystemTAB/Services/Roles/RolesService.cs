using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
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
        public Role Add(RoleDTO entity) {
            throw new NotImplementedException();
        }

        public void Delete(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll() {
            return _rolesRepository.GetAll();
        }

        public Role GetById(Guid id) {
            throw new NotImplementedException();
        }

        public Guid GetRoleIdByName(string roleName)
        {
            return _rolesRepository.GetRoleIdByName(roleName);
        }
    }
}
