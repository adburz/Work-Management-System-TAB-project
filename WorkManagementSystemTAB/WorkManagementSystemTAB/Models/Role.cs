using System;
using System.Collections.Generic;

#nullable disable

namespace WorkManagementSystemTAB.Models
{
    public partial class Role
    {
        public Guid RoleId { get; set; }
        public string Title { get; set; }
        public bool Access1 { get; set; }
        public bool Access2 { get; set; }
        public bool Access3 { get; set; }
    }
}
