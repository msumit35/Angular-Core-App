﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreContext _context;

        public UserRepository(CoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Create(User entity)
        {
            var obj = _context.Users.Add(entity);
            return obj.Entity;
        }

        public async Task Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public int Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(x =>
                x.UserName.ToLower().Equals(userName.ToLower()));
        }

        public async Task<bool> IsUserExists(string username, string email)
        {
            return await _context.Users.AnyAsync(x => x.UserName.ToLower().Equals(username.ToLower()) || x.EmailId.ToLower().Equals(email.ToLower()));
        }
    }
}
