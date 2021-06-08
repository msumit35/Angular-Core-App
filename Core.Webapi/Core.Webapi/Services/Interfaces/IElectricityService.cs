using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Models;

namespace Core.Webapi.Services.Interfaces
{
    public interface IElectricityService : IMakePaymentService
    {
        Task<IEnumerable<ElectricityProvider>> GetElectricityProviders();

        Task<IEnumerable<ElectricityBillModel>> GetElectricityBills();

        Task<ElectricityProvider> CreateElectricityProviderAsync(MasterModel model);

        Task UpdateElectricityProviderAsync(Guid id, MasterModel model);

        Task RemoveElectricityProviderAsync(Guid id);
    }
}
