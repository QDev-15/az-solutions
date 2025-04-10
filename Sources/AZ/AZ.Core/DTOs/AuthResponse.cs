using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiryTime { get; set; }
        public UserResponse User { get; set; }
    }
}
