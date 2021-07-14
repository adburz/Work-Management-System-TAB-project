using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagementSystemTAB.DTO.Request
{
    public class AbsenceTypeUpdateDTO
    {
        public Guid AbsenceTypeId { get; set; }
        public string Name { get; set; }
        public bool? IfShorted { get; set; }
    }
}
