using System;
using System.ComponentModel.DataAnnotations;
using WorkManagementSystemTAB.Models;

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

        public UserResponse() { }

        public UserResponse(User user)
        {
            this.UserId = user.UserId;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.RoleId = user.RoleId;
            this.VacationDaysCount = user.VacationDaysCount;
        }
    }
}
