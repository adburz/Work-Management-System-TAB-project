using System.ComponentModel.DataAnnotations;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.DTO.Request
{
    public class UserRegistrationDTO
    {
       
        [Required]
        //[EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
