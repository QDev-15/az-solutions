
using AZ.Core.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Categories
{
    public class DTO_Category
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships
        public DTO_Category? ParentCategory { get; set; }

        public List<DTO_Category> SubCategories { get; set; } = new List<DTO_Category>();
        public List<DTO_Article> Articles { get; set; } = new List<DTO_Article>();
        public List<DTO_CategoryPermission> CategoryPermissions { get; set; } = new List<DTO_CategoryPermission>();
        public List<DTO_CategoryTranslation> CategoryTranslations { get; set; } = new List<DTO_CategoryTranslation>();
    }
}
