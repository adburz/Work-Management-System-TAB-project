using System;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Roles
{
    public interface IRolesRepository : IRepository<Role, Guid>
    {
        public Role GetRoleByName(string name);
    }
}
