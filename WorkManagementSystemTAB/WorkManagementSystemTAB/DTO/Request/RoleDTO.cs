using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagementSystemTAB.DTO.Request
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }
    }
}
