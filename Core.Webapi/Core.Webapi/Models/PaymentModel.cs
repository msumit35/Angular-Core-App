using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public MobileRechargeModel MobileRecharge { get; set; }

        public ElectricityModel Electricity { get; set; }

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
        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public Guid MobileRechargeTypeId { get; set; }

        [Required]
        public Guid ServiceProviderId { get; set; }
    }

    public class ElectricityModel
    {
        [Required]
        public string ConsumerNumber { get; set; }

        [Required]
        public Guid ElectricityProviderId { get; set; }
    }
}
