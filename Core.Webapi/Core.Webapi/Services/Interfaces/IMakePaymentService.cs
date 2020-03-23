using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Models;

namespace Core.Webapi.Services.Interfaces
{
    public interface IMakePaymentService
    {
        Task<Payment> MakePayment(PaymentModel payment);
    }
}
