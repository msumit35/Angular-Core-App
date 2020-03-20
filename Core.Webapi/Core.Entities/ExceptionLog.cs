using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ExceptionLog : EntityBase
    {
        public ExceptionLog()
        {
            LogTime = DateTimeOffset.Now;
        }
        public string Controller { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTimeOffset LogTime { get; set; }
    }
}
