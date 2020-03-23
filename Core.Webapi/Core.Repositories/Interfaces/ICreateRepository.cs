using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Interfaces
{
    public interface ICreateRepository<T> : IRepository<T>
    {
        Task<T> Create(T entity);
    }
}
