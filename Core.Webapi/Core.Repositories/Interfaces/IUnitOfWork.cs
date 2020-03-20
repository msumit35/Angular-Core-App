using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Interfaces
{
    public interface IUnitOfWork12
    {
        Task<int> SaveChanges();
    }
}
