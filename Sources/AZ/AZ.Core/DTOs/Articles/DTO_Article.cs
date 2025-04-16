using AZ.Core.DTOs.Categories;
using AZ.Core.DTOs.Medias;
using AZ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Articles
{
    public class DTO_Article
    {
        public int Id { get; set; }
        public string Title { set; get; }
        public string Alias { set; get; }
        public bool IsOriginal { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public ArticleStatus Status { get; set; }
        public int Views { set; get; }
        public float RatingResult { set; get; } //caculator rating

        // Relationships
        public DTO_Category Category { get; set; }
        public UserResponse Author { get; set; }
        public DTO_Media Thumbnail { get; set; }
        public ICollection<DTO_Like> Likes { get; set; }
        public ICollection<DTO_Rating> Ratings { get; set; }
        public ICollection<DTO_Tag> Tags { get; set; }
        public ICollection<DTO_ArticleTranslation> ArticleTranslations { get; set; }
    }
}
