using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;

namespace Core.Repositories
{
    public class LinkPaymentsMobileRechargeRepository : ILinkPaymentsMobileRechargeRepository
    {
        private readonly CoreContext _context;

        public LinkPaymentsMobileRechargeRepository(CoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<LinkPaymentMobileRechargeBill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LinkPaymentMobileRechargeBill> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<LinkPaymentMobileRechargeBill> Create(LinkPaymentMobileRechargeBill entity)
        {
            var result = await _context.LinkPaymentsMobileRechargeBills.AddAsync(entity);
            return result.Entity;
        }

        public Task Update(LinkPaymentMobileRechargeBill entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(LinkPaymentMobileRechargeBill entity)
        {
            throw new NotImplementedException();
        }
    }
}
