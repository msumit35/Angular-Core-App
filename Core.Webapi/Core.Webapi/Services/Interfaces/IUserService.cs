using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Webapi.Models;

namespace Core.Webapi.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserExistsAsync(string username, string email);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByUserNameAsync(string username);

        Task<User> CreateAsync(UserModel model);

        Task UpdateUserAsync(Guid id, UserModel model);
    }
}
