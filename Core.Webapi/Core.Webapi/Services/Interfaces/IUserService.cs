﻿using System;
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

        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<User> GetUserByUserNameAsync(string username);

        Task<User> CreateAsync(UserModel model);

        Task UpdateUserAsync(Guid id, UserModel model);

        Task DeactivateUserAsync(Guid id);

        Task ActivateUserAsync(Guid id);

        Task DeleteUserAsync(Guid id);

        Task UnDeleteUserAsync(Guid id);
    }
}
