using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Models;

namespace Core.Webapi.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentMode>> GetPaymentModesAsync();

        Task<PaymentMode> CreatePaymentModeAsync(MasterModel model);

        Task UpdatePaymentModeAsync(Guid id, MasterModel model);

        Task RemovePaymentModeAsync(Guid id);
    }
}
