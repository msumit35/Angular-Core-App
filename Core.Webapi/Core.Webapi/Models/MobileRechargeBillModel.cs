using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Webapi.Models
{
    public class MobileRechargeBillModel
    {
        public string PaymentMode { get; set; }

        public string ServiceProvider { get; set; }

        public decimal Amount { get; set; }

        public string RechargeType { get; set; }

        public string Status { get; set; }
    }
}
