using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Interfaces;

namespace Core.Repositories
{
    public class LinkPaymentsElectricityBillRepository : ILinkPaymentsElectricityBillRepository
    {
        public Task<IEnumerable<LinkPaymentElectricityBills>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LinkPaymentElectricityBills> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LinkPaymentElectricityBills> Create(LinkPaymentElectricityBills entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(LinkPaymentElectricityBills entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(LinkPaymentElectricityBills entity)
        {
            throw new NotImplementedException();
        }
    }
}
