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
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentMode>> GetPaymentModesAsync()
        {
            return await _unitOfWork.PaymentModeRepository.GetAllAsync();
        }

        public async Task<PaymentMode> CreatePaymentModeAsync(MasterModel model)
        {
            var entity = new PaymentMode()
            {
                Name = model.Name,
                Description = model.Description
            };

            return await _unitOfWork.PaymentModeRepository.Create(entity);
        }

        public async Task UpdatePaymentModeAsync(Guid id, MasterModel model)
        {
            var entity = await _unitOfWork.PaymentModeRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception($"Payment mode not found.");
            }

            entity.Name = model.Name;
            entity.Description = model.Description;

            await _unitOfWork.PaymentModeRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemovePaymentModeAsync(Guid id)
        {
            await _unitOfWork.PaymentModeRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
