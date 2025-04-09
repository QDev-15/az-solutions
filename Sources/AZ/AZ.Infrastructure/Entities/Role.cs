using AZ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoleType { get; set; } // Phân loại nhóm

        // Relationship
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<CategoryPermission> CategoryPermissions { get; set; }
    }
}
