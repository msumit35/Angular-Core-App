using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class ElectricityBillRepository : IElectricityBillRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<ElectricityBill> _electricityBills;

        public ElectricityBillRepository(CoreContext context)
        {
            _context = context;
            _electricityBills = _context.ElectricityBills;
        }

        public async Task<IEnumerable<ElectricityBill>> GetAllAsync()
        {
            return await _electricityBills.Include(x => x.Provider).ToListAsync();
        }

        public Task<ElectricityBill> GetByIdAsync(Guid id)
        {
            return _electricityBills.FindAsync(id);
        }

        public async Task<IEnumerable<ElectricityBill>> GetElectricityBillsByCreatedById(Guid id)
        {
            return await _electricityBills.Where(x => x.User.Id == id)
                                        .Include(x => x.Provider)
                                        .Include(x => x.PaymentElectricityBills)
                                        .ToListAsync();
        }

        public async Task<ElectricityBill> Create(ElectricityBill entity)
        {
            var result = await _electricityBills.AddAsync(entity);
            return result.Entity;
        }

    }
}
