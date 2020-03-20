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
    public class ExceptionLogRepository : IExceptionLogRepository
    {
        private readonly CoreContext _context;

        public ExceptionLogRepository(CoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExceptionLog>> GetAllAsync()
        {
            return await _context.ExceptionLogs.ToListAsync();
        }

        public Task<ExceptionLog> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExceptionLog> Create(ExceptionLog entity)
        {
            var obj = _context.ExceptionLogs.Add(entity);
            return obj.Entity;
        }

        public Task Update(ExceptionLog entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(ExceptionLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
