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
    public class PaymentStatusRepository : Repository<PaymentStatus>, IPaymentStatusRepository
    {
        private readonly DbSet<PaymentStatus> _paymentStatuses;

        public PaymentStatusRepository(CoreContext context)
            : base(context)
        {
            _paymentStatuses = context.PaymentStatuses;
        }

        public async Task<PaymentStatus> GetByNameAsync(string name)
        {
            return await _paymentStatuses.SingleOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
