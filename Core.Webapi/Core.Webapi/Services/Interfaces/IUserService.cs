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
        Task<bool> IsUserExists(string username, string email);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByUserName(string username);

        Task<User> Create(UserModel model);
    }
}
