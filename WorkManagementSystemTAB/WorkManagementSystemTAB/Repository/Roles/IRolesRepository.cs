using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Roles
{
    public interface IRolesRepository : IRepository<Role, Guid>
    {
        public Role GetRoleByName(string name);

        public Guid GetRoleIdByName(string name);
        
        public string GetRoleNameById(Guid id);

        public string GetAccessLvlById(Guid id);

        public Role UpdateRole(RoleUpdateDTO role);
    }
}
