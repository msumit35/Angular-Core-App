using Core.Common.Interfaces;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

namespace Core.Webapi.Services
{
    public abstract class MakePaymentService : IMakePaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoreUserContext _userContext;

        protected MakePaymentService(IUnitOfWork unitOfWork, ICoreUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public virtual async Task<Payment> MakePaymentAsync(PaymentModel model)
        {
            Thread.Sleep(new Random().Next(3000, 6000));

            var status = new Random().Next(1, 2);

            var payment = new Payment
            {
                Amount = model.Amount,
                User = await _unitOfWork.UserRepository.GetByIdAsync(_userContext.UserId),
                PaymentMode = await _unitOfWork.PaymentModeRepository.GetByIdAsync(model.PaymentModeId)
            };

            if (status == (int)PaymentStatus.Success)
                payment.PaymentStatus = await _unitOfWork.PaymentStatusRepository.GetByNameAsync("success");
            else
            {
                payment.PaymentStatus = await _unitOfWork.PaymentStatusRepository.GetByNameAsync("failed");
                payment.FailureDescription = "Test failure payment";
            }

            payment = await _unitOfWork.PaymentRepository.Create(payment);
            await ProcessPaymentAsync(model, payment);

            return payment;
        }

        protected abstract Task ProcessPaymentAsync(PaymentModel model, Payment payment);
    }
}
