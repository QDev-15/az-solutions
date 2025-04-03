using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class ArticleTranslation
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public int? OgImageId { get; set; }

        // Relationships
        public Article Article { get; set; }
        public Media OgImage { get; set; }
    }

}
