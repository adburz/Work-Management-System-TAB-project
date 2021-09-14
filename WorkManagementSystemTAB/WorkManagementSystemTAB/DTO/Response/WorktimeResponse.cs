using System;

namespace WorkManagementSystemTAB.DTO.Response
{
    public class WorktimeResponse
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid WorktimeId { get; set; }
    }
}
