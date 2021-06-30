using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagementSystemTAB.DTO.Response
{
    public class UserDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public int VacationDaysCount { get; set; }
    }
}
