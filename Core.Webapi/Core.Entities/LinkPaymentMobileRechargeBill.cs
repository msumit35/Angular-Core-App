using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class LinkPaymentMobileRechargeBill : EntityBase
    {
        public Guid PaymentId { get; set; }
        public Guid MobileRechargeBillId { get; set; }

        public Payment Payment { get; set; }
        public MobileRechargeBill MobileRechargeBill { get; set; }
    }
}
