using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Webapi.Models
{
    public class Response
    {
        public int Status { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
