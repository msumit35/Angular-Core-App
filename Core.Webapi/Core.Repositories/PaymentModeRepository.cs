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
    public class PaymentModeRepository : IPaymentModeRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<PaymentMode> _paymentModes;

        public PaymentModeRepository(CoreContext context)
        {
            _context = context;
            _paymentModes = context.PaymentModes;
        }

        public async Task<IEnumerable<PaymentMode>> GetAllAsync()
        {
            return await _paymentModes.ToListAsync();
        }

        public async Task<PaymentMode> GetByIdAsync(Guid id)
        {
            return await _paymentModes.FindAsync(id);
        }
    }
}
