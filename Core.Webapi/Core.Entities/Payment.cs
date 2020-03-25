using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class Payment : CreateEntityBase
    {
        public Guid PaymentModeId { get; set; }

        public Guid PaymentStatusId { get; set; }

        public decimal Amount { get; set; }

        public string FailureDescription { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public List<LinkPaymentElectricityBill> PaymentsElectricityBills { get; set; }
    }
}
