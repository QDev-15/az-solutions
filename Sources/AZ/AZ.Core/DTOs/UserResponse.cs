using AZ.Core.DTOs.Roles;
using AZ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string DisplayName { 
            get {
                if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
                {
                    return $"{FirstName} {LastName}".Trim();
                }
                return Email ?? Username;
            }  
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { set; get; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { set; get; }


        // Relationship
        public string Avatar { set; get; }
        public string Thumbnail { set; get; }
        public List<DTO_UserRole> UserRoles { set; get; } = new List<DTO_UserRole>();
    }
}
