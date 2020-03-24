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
    public class MobileRechargeBillRepository : IMobileRechargeBillRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<MobileRechargeBill> _mobileRechargeBills;

        public MobileRechargeBillRepository(CoreContext context)
        {
            _context = context;
            _mobileRechargeBills = context.MobileRechargeBills;
        }

        public async Task<IEnumerable<MobileRechargeBill>> GetAllAsync()
        {
            return await _mobileRechargeBills
                            .Include(x => x.ServiceProvider)
                            .Include(x => x.MobileRechargeType)
                            .ToListAsync();
        }

        public async Task<MobileRechargeBill> GetByIdAsync(Guid id)
        {
            return await _mobileRechargeBills.FindAsync(id);
        }

        public async Task<MobileRechargeBill> Create(MobileRechargeBill entity)
        {
            var result = await _mobileRechargeBills.AddAsync(entity);
            return result.Entity;
        }
    }
}
