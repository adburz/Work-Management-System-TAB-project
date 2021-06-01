using System.Collections.Generic;

namespace WorkManagementSystemTAB.Configuration
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
