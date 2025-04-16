using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Roles
{
    public class DTO_Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoleType { get; set; } // Phân loại nhóm
    }
}
