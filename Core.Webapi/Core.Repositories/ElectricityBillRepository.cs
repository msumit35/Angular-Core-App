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
            return await _electricityBills.ToListAsync();
        }

        public Task<ElectricityBill> GetByIdAsync(Guid id)
        {
            return _electricityBills.FindAsync(id);
        }

        public async Task<ElectricityBill> Create(ElectricityBill entity)
        {
            var result = await _electricityBills.AddAsync(entity);
            return result.Entity;
        }
    }
}
