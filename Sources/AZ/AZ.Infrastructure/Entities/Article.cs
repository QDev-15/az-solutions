using AZ.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { set; get; }
        public string Alias { set; get; }
        public int CategoryId { get; set; }
        public bool IsOriginal { get; set; }
        public string Source { get; set; }
        public int AuthorId { get; set; }
        public int? ThumbnailId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public ArticleStatus Status { get; set; }
        public int Views { set; get; }
        public float RatingResult { set; get; } //caculator rating

        // Relationships
        public Category Category { get; set; }
        public User Author { get; set; }
        public Media Thumbnail { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<ArticleTranslation> ArticleTranslations { get; set; }
    }

}
