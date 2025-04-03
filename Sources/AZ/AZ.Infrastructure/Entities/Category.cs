using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<CategoryPermission> CategoryPermissions { get; set; } = new List<CategoryPermission>();
        public ICollection<CategoryTranslation> CategoryTranslations { get; set; } = new List<CategoryTranslation>();
    }

}
