using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class LinkPaymentsElectricityBillRepository : ILinkPaymentsElectricityBillRepository
    {
        private readonly CoreContext _context;

        public LinkPaymentsElectricityBillRepository(CoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LinkPaymentElectricityBill>> GetAllAsync()
        {
            return await _context.LinkPaymentsElectricityBills.ToListAsync();
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
