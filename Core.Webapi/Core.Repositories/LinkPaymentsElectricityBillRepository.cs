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
        public Task<IEnumerable<LinkPaymentElectricityBill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LinkPaymentElectricityBill> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LinkPaymentElectricityBill> Create(LinkPaymentElectricityBill entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(LinkPaymentElectricityBill entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(LinkPaymentElectricityBill entity)
        {
            throw new NotImplementedException();
        }
    }
}
