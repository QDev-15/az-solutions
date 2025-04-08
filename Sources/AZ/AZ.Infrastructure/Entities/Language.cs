using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Entities
{
    public class Language
    {
        public string Code { get; set; } = default!;  // ví dụ: "en", "vi"
        public string DisplayName { get; set; } = default!; // English, Vietnamese
        public string NativeName { get; set; } = default!; // English, Tiếng Việt

        public bool IsDefault { get; set; } = false;

        public bool IsEnabled { get; set; } = true;
    }
}
