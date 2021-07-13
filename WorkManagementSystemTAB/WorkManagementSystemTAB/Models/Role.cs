using System;

#nullable disable

namespace WorkManagementSystemTAB.Models
{
    public partial class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }
    }
}

