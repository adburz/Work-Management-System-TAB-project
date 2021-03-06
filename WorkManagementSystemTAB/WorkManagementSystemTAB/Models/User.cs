using System;


#nullable disable

namespace WorkManagementSystemTAB.Models
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid RoleId { get; set; }
        public int VacationDaysCount { get; set; }
    }
}
