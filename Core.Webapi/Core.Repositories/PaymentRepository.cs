using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Interfaces;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<Payment> _payments;

        public PaymentRepository(CoreContext context)
        {
            _context = context;
            _payments = context.Payments;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _payments
                            .Include(x => x.PaymentStatus)
                            .Include(x => x.PaymentMode)
                            .ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(Guid id)
        {
            return await _payments.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCreatedById(Guid id)
        {
            return await _payments.Where(x => x.User.Id == id)
                                .Include(x => x.PaymentStatus)
                                .Include(x => x.PaymentMode)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByIds(IEnumerable<Guid> ids)
        {
            return await _payments.Where(x => ids.Contains(x.Id))
                                    .Include(x => x.PaymentStatus)
                                    .Include(x => x.PaymentMode)
                                    .ToListAsync();
        }

        public async Task<Payment> Create(Payment entity)
        {
            var result = await _payments.AddAsync(entity);
            return result.Entity;
        }
    }
}
