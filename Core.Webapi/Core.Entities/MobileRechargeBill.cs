using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class MobileRechargeBill : CrudEntityBase
    {
        public Guid ServiceProviderId { get; set; }
        public Guid MobileRechargeTypeId { get; set; }

        public MobileRechargeType Type { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
    }
}
