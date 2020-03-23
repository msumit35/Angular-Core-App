using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Core.Entities
{
    public class Payment : CreateEntityBase
    {
        public Guid PaymentModeId { get; set; }
        public Guid PaymentStatusId { get; set; }
        public double Amount { get; set; }
        public string FailureDescription { get; set; }

        public PaymentStatus Status { get; set; }
        public PaymentMode Mode { get; set; }
    }
}
