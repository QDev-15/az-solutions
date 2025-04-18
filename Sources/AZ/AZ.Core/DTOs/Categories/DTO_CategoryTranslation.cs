using AZ.Core.DTOs.Languges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Categories
{
    public class DTO_CategoryTranslation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }


        // Relationships
        public DTO_Category? Category { get; set; }
        public DTO_Language? Language { get; set; }
    }
}
