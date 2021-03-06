﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class MobileRechargeBill : CreateEntityBase
    {
        public MobileRechargeBill()
        {
            PaymentsMobileRechargeBills = new List<LinkPaymentMobileRechargeBill>();
        }

        public string MobileNumber { get; set; }

        public Guid ServiceProviderId { get; set; }

        public Guid MobileRechargeTypeId { get; set; }

        public MobileRechargeType MobileRechargeType { get; set; }

        public ServiceProvider ServiceProvider { get; set; }

        public List<LinkPaymentMobileRechargeBill> PaymentsMobileRechargeBills { get; set; }
    }
}
