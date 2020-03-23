using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Interfaces;
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
    }
}
