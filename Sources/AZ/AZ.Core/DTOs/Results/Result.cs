using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Results
{
    public class Result
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
