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
            if (_rolesRepository.GetRoleByName(entity.Name)?.AccessLevel == entity.AccessLevel) return null;
            var newRole = new Role() { AccessLevel = entity.AccessLevel, Name = entity.Name, RoleId = Guid.NewGuid() };
            return  _rolesRepository.Add(newRole); 
        }

        public void Delete(Guid id) {
            _rolesRepository.Delete(id);
        }

        public IEnumerable<Role> GetAll() {
            return _rolesRepository.GetAll();
        }

        public Role GetById(Guid id) {
            return _rolesRepository.GetById(id);
        }

        public Guid GetRoleIdByName(string roleName)
        {
            return _rolesRepository.GetRoleIdByName(roleName);
        }

        public Role UpdateRole(RoleUpdateDTO role)
        {
            return _rolesRepository.UpdateRole(role);
        }

        public string GetAccessLvlById(Guid id)
        {
            return _rolesRepository.GetAccessLvlById(id);
        }
    }
}
