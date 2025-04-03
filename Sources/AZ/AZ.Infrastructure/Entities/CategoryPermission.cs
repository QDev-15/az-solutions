using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class CategoryPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int RoleId { get; set; }

        // Relationships
        public User User { get; set; }
        public Category Category { get; set; }
        public Role Role { get; set; }
    }

}
