using Core.Common.Interfaces;
using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Webapi.Models;
using Core.Webapi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Webapi.Services
{
    public class MobileRechargeService : MakePaymentService, IMobileRechargeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoreUserContext _userContext;

        public MobileRechargeService(IUnitOfWork unitOfWork, ICoreUserContext userContext)
        : base(unitOfWork, userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
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
                var payments = await _unitOfWork.PaymentRepository.GetPaymentsByCreatedById(_userContext.UserId);
                var bills = await _unitOfWork.MobileRechargeBillRepository.GetAllAsync();
                var paymentsBillsLink = await _unitOfWork.LinkPaymentsMobileRechargeRepository.GetAllAsync();

                var list = from b in bills
                           join pbl in paymentsBillsLink on b.Id equals pbl.MobileRechargeBillId
                           join p in payments on pbl.PaymentId equals p.Id
                           select new MobileRechargeBillModel
                           {
                               MobileNumber = b.MobileNumber,
                               Status = p.PaymentStatus.Name,
                               ServiceProvider = b.ServiceProvider.Name,
                               PaymentMode = p.PaymentMode.Name,
                               Amount = p.Amount,
                               RechargeType = b.MobileRechargeType.Name,
                               CreatedOn = p.CreatedOn
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

                var mobileRecharge = new MobileRechargeBill
                {
                    MobileRechargeType =
                        await _unitOfWork.MobileRechargeTypeRepository.GetByIdAsync(model.MobileRecharge
                            .MobileRechargeTypeId),
                    ServiceProvider =
                        await _unitOfWork.ServiceProviderRepository.GetByIdAsync(model.MobileRecharge
                            .ServiceProviderId),
                    User = payment.User,
                    MobileNumber = model.MobileRecharge.MobileNumber
                };

                var link = new LinkPaymentMobileRechargeBill
                {
                    MobileRechargeBill = mobileRecharge,
                    Payment = payment
                };
                mobileRecharge.PaymentsMobileRechargeBills.Add(link);

                await _unitOfWork.MobileRechargeBillRepository.Create(mobileRecharge);
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
