using AZ.Core.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Categories
{
    public class DTO_CategoryPermission
    {
        public int Id { get; set; }

        // Relationships
        public UserResponse? User { get; set; }
        public DTO_Category? Category { get; set; }
        public DTO_Role? Role { get; set; }
    }
}
