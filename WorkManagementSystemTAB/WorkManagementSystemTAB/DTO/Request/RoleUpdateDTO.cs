using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkManagementSystemTAB.DTO.Request
{
    public class RoleUpdateDTO
    {
        public Guid RoleId { get; set; }
        public string? Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AccessLevelEnum? AccessLevel { get; set; }
    }
}
