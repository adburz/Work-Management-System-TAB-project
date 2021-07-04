using System;

namespace WorkManagementSystemTAB.DTO.Request
{
    public class WorktimeDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid UserId { get; set; }
    }
}