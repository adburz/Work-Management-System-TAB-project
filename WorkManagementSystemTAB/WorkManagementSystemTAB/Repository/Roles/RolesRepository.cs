using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.Models;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;

namespace WorkManagementSystemTAB.Repository.Roles
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {

        public RolesRepository(TABWorkManagementSystemContext context) : base(context) { }

        public Role Add(Role entity)
        {
            _context.Add(entity);
            this.Save();
            return entity;
        }

        public void Delete(Guid id)
        {
            var roleToDelete = GetById(id);
            if (roleToDelete != null)
            {
                _context.Remove(roleToDelete);
            }
            this.Save();
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            return _context.Roles.FirstOrDefault(x => x.RoleId == id);
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
            var x = _context.Roles.FirstOrDefault(x => id.Equals(x.RoleId));
            return x.AccessLevel.ToString();
        }

        public Role UpdateRole(RoleUpdateDTO role)
        {
            var foundRole = GetById(role.RoleId);

            if (foundRole == null)
                return null;

            if (!string.IsNullOrEmpty(role.Name))
                foundRole.Name = role.Name;

            if ( role.AccessLevel != null)
                foundRole.AccessLevel = (AccessLevelEnum)role.AccessLevel;

            Save();

            return foundRole;
        }
    }
}
