using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Interfaces
{
    public interface ICrudRepository<T> : ICreateRepository<T>
    {
        Task Update(T entity);

        int Remove(T entity);
    }
}
