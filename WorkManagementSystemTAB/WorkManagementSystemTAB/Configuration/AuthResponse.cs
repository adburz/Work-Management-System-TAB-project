using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Response;

namespace WorkManagementSystemTAB.Configuration
{
    public class AuthResponse
    {
        public UserResponse LoggedUser { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
