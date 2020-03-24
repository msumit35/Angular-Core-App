using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Interfaces;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;

namespace Core.Webapi.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoreUserContext _userContext;

        public UserService(IUnitOfWork unitOfWork, ICoreUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public Task<bool> IsUserExistsAsync(string username, string email)
        {
            return _unitOfWork.UserRepository.IsUserExists(username, email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _unitOfWork.UserRepository.GetUserByUserName(username);
        }

        public async Task<User> CreateAsync(UserModel model)
        {
            var entity = Converter.GetUser(model);
            entity.User = await _unitOfWork.UserRepository.GetByIdAsync(_userContext.UserId);

            entity = await _unitOfWork.UserRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }
    }
}
