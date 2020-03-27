using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Interfaces
{
    public interface ICrudRepository<T> : ICreateRepository<T>
    {
        Task UpdateAsync(T entity);

        Task RemoveAsync(Guid id);
    }
}
