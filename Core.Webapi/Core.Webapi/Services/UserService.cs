using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;

namespace Core.Webapi.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> IsUserExists(string username, string email)
        {
            return _unitOfWork.UserRepository.IsUserExists(username, email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetUserByUserName(string username)
        {
            return await _unitOfWork.UserRepository.GetUserByUserName(username);
        }

        public async Task<User> Create(UserModel model)
        {
            var entity = Converter.GetUser(model);

            entity = await _unitOfWork.UserRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }
    }
}
