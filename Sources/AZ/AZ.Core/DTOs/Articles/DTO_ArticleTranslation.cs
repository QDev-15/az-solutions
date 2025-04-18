using AZ.Core.DTOs.Languges;
using AZ.Core.DTOs.Medias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Articles
{
    public class DTO_ArticleTranslation
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Slug { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }

        // Relationships
        public DTO_Media? OgImage { get; set; }
        public DTO_Language? Language { set; get; }
    }
}
