using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;

namespace Core.Repositories
{
    public class CreateRepository<T> : Repository<T>, ICreateRepository<T>
        where T : CreateEntityBase
    {
        private readonly CoreContext _context;

        public CreateRepository(CoreContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
    }
}
