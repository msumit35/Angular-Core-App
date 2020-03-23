using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Models;

namespace Core.Webapi.Services.Interfaces
{
    public interface IMobileRechargeService : IMakePaymentService
    {
        Task<IEnumerable<ServiceProvider>> GetServiceProvidersAsync();

        Task<IEnumerable<MobileRechargeType>> GetRechargeTypesAsync();

        Task<IEnumerable<MobileRechargeBillModel>> GetMobileRechargeBillsAsync();
    }
}
