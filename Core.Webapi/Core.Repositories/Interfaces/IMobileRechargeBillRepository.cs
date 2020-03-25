using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IMobileRechargeBillRepository : ICreateRepository<MobileRechargeBill>
    {
        Task<IEnumerable<MobileRechargeBill>> GetMobileRechargeBillsByCreatedById(Guid id);
    }
}
