using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class UserSession
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }

        public string? AccessToken { get; set; } // Optional, useful for diagnostics or auditing
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }

        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? TimeZone { get; set; }
        public bool IsActive => RevokedAt == null && RefreshTokenExpiry > DateTime.UtcNow;
    }

}
