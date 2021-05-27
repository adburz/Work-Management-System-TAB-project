using System;
using System.Collections.Generic;

#nullable disable

namespace WorkManagementSystemTAB.Models
{
    public partial class AbsenceType
    {
        public Guid AbsenceTypeId { get; set; }
        public string Name { get; set; }
        public bool IfShorted { get; set; }
    }
}
