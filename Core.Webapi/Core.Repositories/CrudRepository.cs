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
    public class CrudRepository<T> : CreateRepository<T>, ICrudRepository<T>
        where T : CrudEntityBase
    {
        private readonly CoreContext _context;

        public CrudRepository(CoreContext context)
            : base(context)
        {
            _context = context;
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.RemovedOn = DateTimeOffset.Now;
        }
    }
}
