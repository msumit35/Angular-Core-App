using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<User> GetUserByUserName(string userName);
        Task<bool> IsUserExists(string username, string email);
    }
}
