using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Webapi.Attributes;

namespace Core.Webapi.Models
{
    public class PaymentModel
    {
        [Required]
        public PaymentModule Module { get; set; }

        [Required]
        public Guid PaymentModeId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [RequiredBasedOnModule(PaymentModule.MobileRecharge)]
        public MobileRechargeModel MobileRecharge { get; set; }

        [RequiredBasedOnModule(PaymentModule.Electricity)]
        public ElectricityModel ElectricityRecharge { get; set; }

        public PaymentStatus Status { get; set; }
    }

    public enum PaymentModule
    {
        Electricity = 1,
        MobileRecharge
    }

    public enum PaymentStatus
    {
        Success,
        Failed
    }

    public class MobileRechargeModel
    {
        public string MobileNumber { get; set; }

        public Guid MobileRechargeTypeId { get; set; }

        public Guid ServiceProviderId { get; set; }
    }

    public class ElectricityModel
    {
        public string ConsumerNumber { get; set; }

        public Guid ElectricityProviderId { get; set; }
    }
}
