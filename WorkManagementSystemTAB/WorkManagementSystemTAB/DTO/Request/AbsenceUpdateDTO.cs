using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagementSystemTAB.DTO.Request
{
    public class AbsenceUpdateDTO
    {
        public Guid AbsenceId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AbsenceTypeId { get; set; }
        public bool? Confirmed { get; set; }
    }
}