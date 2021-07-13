using System.ComponentModel.DataAnnotations;


namespace WorkManagementSystemTAB.DTO.Request
{
    public class UserRegistrationDTO
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
