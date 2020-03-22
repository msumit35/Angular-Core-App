﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class MobileRechargeTypeRepository : IMobileRechargeTypeRepository
    {
        private readonly CoreContext _context;
        private readonly DbSet<MobileRechargeType> _mobileRechargeTypes;

        public MobileRechargeTypeRepository(CoreContext context)
        {
            _context = context;
            _mobileRechargeTypes = context.MobileRechargeTypes;
        }

        public async Task<IEnumerable<MobileRechargeType>> GetAllAsync()
        {
            return await _mobileRechargeTypes.ToListAsync();
        }

        public async Task<MobileRechargeType> GetByIdAsync(Guid id)
        {
            return await _mobileRechargeTypes.FindAsync(id);
        }
    }
}