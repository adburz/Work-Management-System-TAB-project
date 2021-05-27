using System;
using System.Collections.Generic;

#nullable disable

namespace WorkManagementSystemTAB.Models
{
    public partial class Worktime
    {
        public Guid WorktimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User User { get; set; }
    }
}
