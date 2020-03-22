using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class LinkPaymentElectricityBills : EntityBase
    {
        public Guid PaymentId { get; set; }
        public Guid ElectricityBillId { get; set; }

        public Payment Payment { get; set; }
        public ElectricityBill ElectricityBill { get; set; }
    }
}
