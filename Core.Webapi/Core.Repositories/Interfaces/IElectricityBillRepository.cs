using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IElectricityBillRepository : ICreateRepository<ElectricityBill>
    {
        Task<IEnumerable<ElectricityBill>> GetElectricityBillsByCreatedById(Guid id);
    }
}
