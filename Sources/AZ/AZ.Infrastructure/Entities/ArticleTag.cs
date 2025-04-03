using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class ArticleTag
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        // Relationships
        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }

}
