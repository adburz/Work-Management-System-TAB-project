using System;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Roles
{
    public interface IRolesService : IService<Role, Guid>
    {
        public Guid GetRoleIdByName(string roleName);
    }
}
