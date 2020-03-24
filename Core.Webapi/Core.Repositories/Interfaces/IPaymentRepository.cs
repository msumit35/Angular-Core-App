using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IPaymentRepository : ICreateRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsByCreatedById(Guid id);
    }
}
