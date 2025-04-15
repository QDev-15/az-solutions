using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Results
{
    public class ResultSuccessfull : Result
    {
        public ResultSuccessfull()
        {
            IsSuccessed = true;
        }
        public ResultSuccessfull(string message)
        {
            IsSuccessed = true;
            Message = message;
        }
        public ResultSuccessfull(object data)
        {
            IsSuccessed = true;
            Data = data;
        }
        public ResultSuccessfull(string message, object data)
        {
            IsSuccessed = true;
            Message = message;
            Data = data;
        }
    }
}
