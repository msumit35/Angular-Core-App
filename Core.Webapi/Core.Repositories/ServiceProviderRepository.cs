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
    public class ServiceProviderRepository : IServiceProviderRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<ServiceProvider> _serviceProviders;

        public ServiceProviderRepository(CoreContext context)
        {
            _context = context;
            _serviceProviders = context.ServiceProviders;
        }

        public async Task<IEnumerable<ServiceProvider>> GetAllAsync()
        {
            return await _serviceProviders.ToListAsync();
        }

        public async Task<ServiceProvider> GetByIdAsync(Guid id)
        {
            return await _serviceProviders.FindAsync(id);
        }
    }
}
