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
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<PaymentStatus> _paymentStatuses;

        public PaymentStatusRepository(CoreContext context)
        {
            _context = context;
            _paymentStatuses = context.PaymentStatuses;
        }

        public async Task<IEnumerable<PaymentStatus>> GetAllAsync()
        {
            return await _paymentStatuses.ToListAsync();
        }

        public async Task<PaymentStatus> GetByIdAsync(Guid id)
        {
            return await _paymentStatuses.FindAsync(id);
        }

        public async Task<PaymentStatus> GetByNameAsync(string name)
        {
            return await _paymentStatuses.SingleOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
