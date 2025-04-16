using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Medias
{
    public class DTO_Media
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Thumbnail { get; set; }
        public string AltText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
