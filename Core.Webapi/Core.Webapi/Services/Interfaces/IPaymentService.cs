using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Webapi.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentMode>> GetPaymentModesAsync();
    }
}
