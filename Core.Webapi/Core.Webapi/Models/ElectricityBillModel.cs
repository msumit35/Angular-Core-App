using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Webapi.Models
{
    public class ElectricityBillModel
    {
        public string ConsumerNumber { get; set; }

        public string Provider { get; set; }

        public string PaymentMode { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
