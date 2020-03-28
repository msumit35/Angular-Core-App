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
            return _unitOfWork.UserRepository.IsUserExistsAsync(username, email);
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var response = new List<UserModel>();

            foreach (var item in users)
            {
                response.Add(new UserModel(item, null));
            }

            return response;
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _unitOfWork.UserRepository.GetUserByUserNameAsync(username);
        }

        public async Task<User> CreateAsync(UserModel model)
        {
            var entity = Converter.GetUser(model);
            entity.User = await _unitOfWork.UserRepository.GetByIdAsync(_userContext.UserId);

            entity = await _unitOfWork.UserRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateUserAsync(Guid id, UserModel model)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception($"User not found. UserId: {id}");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.Username;

            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task DeactivateUserAsync(Guid id)
        {
            await _unitOfWork.UserRepository.DeactivatedUserAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ActivateUserAsync(Guid id)
        {
            await _unitOfWork.UserRepository.ActivateUserAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _unitOfWork.UserRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UnDeleteUserAsync(Guid id)
        {
            await _unitOfWork.UserRepository.UndoRemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
