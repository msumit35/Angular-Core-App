using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Interfaces
{
    public interface ICrudRepository<T> : IRepository<T>
    {
        Task<T> Create(T entity);
        Task Update(T entity);
        int Remove(T entity);
    }
}
