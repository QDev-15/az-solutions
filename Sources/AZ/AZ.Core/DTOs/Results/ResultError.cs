using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Core.DTOs.Results
{
    public class ResultError : Result
    {
        public ResultError()
        {
            IsSuccessed = false;
        }
        public ResultError(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
        public ResultError(object data)
        {
            IsSuccessed = false;
            Data = data;
        }
        public ResultError(string message, object data)
        {
            IsSuccessed = false;
            Message = message;
            Data = data;
        }
    }
}
