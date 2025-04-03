using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string AltText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships

        public ICollection<User> Users { set; get; } = new List<User>();
        public ICollection<Article> Articles { set; get; } = new List<Article>();
    }

}
