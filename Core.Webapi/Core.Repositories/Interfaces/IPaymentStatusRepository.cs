using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IPaymentStatusRepository : IRepository<PaymentStatus>
    {
        Task<PaymentStatus> GetByNameAsync(string name);
    }
}
