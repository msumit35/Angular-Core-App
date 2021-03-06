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
    public class ExceptionLogRepository : Repository<ExceptionLog>, IExceptionLogRepository
    {
        private readonly CoreContext _context;

        public ExceptionLogRepository(CoreContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<ExceptionLog> Create(ExceptionLog entity)
        {
            var obj = await _context.ExceptionLogs.AddAsync(entity);
            return obj.Entity;
        }
    }
}
