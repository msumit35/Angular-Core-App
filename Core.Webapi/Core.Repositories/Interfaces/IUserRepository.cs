using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<User> GetUserByUserNameAsync(string userName);

        Task<bool> IsUserExistsAsync(string username, string email);

        Task ActivateUserAsync(Guid id);

        Task DeactivatedUserAsync(Guid id);

        Task UndoRemoveAsync(Guid id);
    }
}
