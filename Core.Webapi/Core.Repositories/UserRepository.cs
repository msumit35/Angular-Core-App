using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccessLayer;
using Core.Entities;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CoreContext _context;

        public UserRepository(CoreContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> Create(User entity)
        {
            var obj = await _context.Users.AddAsync(entity);
            return obj.Entity;
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.RemovedOn = DateTimeOffset.Now;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(x =>
                x.UserName.ToLower().Equals(userName.ToLower()));
        }

        public async Task<bool> IsUserExistsAsync(string username, string email)
        {
            return await _context.Users.AnyAsync(x => x.UserName.ToLower().Equals(username.ToLower()) || x.EmailId.ToLower().Equals(email.ToLower()));
        }

        public async Task ActivateUserAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsActivated = true;
        }

        public async Task DeactivatedUserAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsActivated = false;
        }

        public async Task UndoRemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.RemovedOn = null;
        }
    }
}
