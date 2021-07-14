using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Roles
{
    public interface IRolesService : IService<Role, Guid,RoleDTO>
    {
        public Guid GetRoleIdByName(string roleName);
        Role UpdateRole(RoleUpdateDTO role);
        public string GetAccessLvlById(Guid id);
    }
}
