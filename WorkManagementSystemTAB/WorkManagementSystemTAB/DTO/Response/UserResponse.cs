using System;
using System.ComponentModel.DataAnnotations;

namespace WorkManagementSystemTAB.DTO.Response
{
    public class UserResponse
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
