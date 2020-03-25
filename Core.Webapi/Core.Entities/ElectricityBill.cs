using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ElectricityBill : CreateEntityBase
    {
        public ElectricityBill()
        {
            PaymentElectricityBills = new List<LinkPaymentElectricityBill>();    
        }

        public string ConsumerNumber { get; set; }

        public Guid ElectricityProviderId { get; set; }

        public ElectricityProvider Provider { get; set; }

        public List<LinkPaymentElectricityBill> PaymentElectricityBills { get; set; }

    }
}
