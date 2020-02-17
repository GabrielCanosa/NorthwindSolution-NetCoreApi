using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWebApi.GlobalErrorHandling
{
    public class ErrorDetails
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
