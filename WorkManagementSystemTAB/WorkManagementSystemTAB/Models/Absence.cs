using System;
using System.Collections.Generic;

#nullable disable

namespace WorkManagementSystemTAB.Models
{
    public partial class Absence
    {
        public Guid AbsenceId { get; set; }
        public bool Confirmed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public Guid AbsenceTypeId { get; set; }
    }
}
