using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ElectricityBill : CreateEntityBase
    {
        public string ConsumerNumber { get; set; }
        public Guid ElectricityProviderId { get; set; }

        public ElectricityProvider Provider { get; set; }
    }
}
