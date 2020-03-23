using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis.CSharp;
using Remotion.Linq.Clauses;
using PaymentStatus = Core.Webapi.Models.PaymentStatus;

namespace Core.Webapi.Services
{
    public class MobileRechargeService : MakePaymentService, IMobileRechargeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MobileRechargeService(IUnitOfWork unitOfWork)
        : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<ServiceProvider>> GetServiceProvidersAsync()
        {
            return _unitOfWork.ServiceProviderRepository.GetAllAsync();
        }

        public Task<IEnumerable<MobileRechargeType>> GetRechargeTypesAsync()
        {
            return _unitOfWork.MobileRechargeTypeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<MobileRechargeBillModel>> GetMobileRechargeBillsAsync()
        {
            try
            {
                var payments = await _unitOfWork.PaymentRepository.GetAllAsync();
                var bills = await _unitOfWork.MobileRechargeBillRepository.GetAllAsync();
                var paymentsBillsLink = await _unitOfWork.LinkPaymentsMobileRechargeRepository.GetAllAsync();

                var list = from b in bills
                    join pbl in paymentsBillsLink on b.Id equals pbl.MobileRechargeBillId
                    join p in payments on pbl.PaymentId equals p.Id
                    select new MobileRechargeBillModel
                    {
                        Status = p.PaymentStatus.Name,
                        ServiceProvider = b.ServiceProvider.Name,
                        PaymentMode = p.PaymentMode.Name,
                        Amount = p.Amount,
                        RechargeType = b.MobileRechargeType.Name
                    };

                return list;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public override async Task<Payment> MakePaymentAsync(PaymentModel model)
        {
            try
            {
                var payment = await base.MakePaymentAsync(model);
                var mobileRecharge = new MobileRechargeBill();
                mobileRecharge.MobileRechargeType = await _unitOfWork.MobileRechargeTypeRepository.GetByIdAsync(model.MobileRecharge.MobileRechargeTypeId);
                mobileRecharge.ServiceProvider =
                    await _unitOfWork.ServiceProviderRepository.GetByIdAsync(model.MobileRecharge.ServiceProviderId);

                payment = await _unitOfWork.PaymentRepository.Create(payment);
                mobileRecharge = await _unitOfWork.MobileRechargeBillRepository.Create(mobileRecharge);

                var link = new LinkPaymentMobileRechargeBill();
                link.MobileRechargeBill = mobileRecharge;
                link.Payment = payment;

                await _unitOfWork.LinkPaymentsMobileRechargeRepository.Create(link);

                await _unitOfWork.SaveChangesAsync();

                return payment;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
