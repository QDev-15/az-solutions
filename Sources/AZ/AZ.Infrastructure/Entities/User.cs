using AZ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { set; get; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? AvatarId { set; get; }
        public UserStatus? Status { set; get; }


        // Relationship
        public Media Avatar { set; get; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<CategoryPermission> CategoryPermissions { get; set; } = new List<CategoryPermission>();
    }

}
