using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class MobileRechargeBill : CreateEntityBase
    {
        public Guid ServiceProviderId { get; set; }
        public Guid MobileRechargeTypeId { get; set; }

        public MobileRechargeType MobileRechargeType { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
    }
}
