using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Handler
{
    public class ErrorResponse
    {
        public int StatusCode {get; set;}
        public string Message {get; set;} = null!;
        public string ErrorAt {get; set;} = null!;
    }
}