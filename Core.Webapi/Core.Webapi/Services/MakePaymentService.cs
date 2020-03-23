﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

namespace Core.Webapi.Services
{
    public abstract class MakePaymentService : IMakePaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected MakePaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<Payment> MakePaymentAsync(PaymentModel model)
        {
            try
            {
                var payment = new Payment();
                payment.Amount = model.Amount;
                payment.PaymentMode = await _unitOfWork.PaymentModeRepository.GetByIdAsync(model.PaymentModeId);

                if (model.Status == PaymentStatus.Success)
                    payment.PaymentStatus = await _unitOfWork.PaymentStatusRepository.GetByNameAsync("success");
                else
                {
                    payment.PaymentStatus = await _unitOfWork.PaymentStatusRepository.GetByNameAsync("failed");
                    payment.FailureDescription = "Test failure payment";
                }

                return payment;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
