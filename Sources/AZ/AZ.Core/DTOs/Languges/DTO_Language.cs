using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Languges
{
    public class DTO_Language
    {
        public string Code { get; set; } = default!;  // ví dụ: "en", "vi"
        public string DisplayName { get; set; } = default!; // English, Vietnamese
        public string NativeName { get; set; } = default!; // English, Tiếng Việt

        public bool IsDefault { get; set; } = false;

        public bool IsEnabled { get; set; } = true;
    }
}
