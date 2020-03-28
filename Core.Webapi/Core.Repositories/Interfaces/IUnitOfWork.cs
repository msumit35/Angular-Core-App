using System.Threading.Tasks;
using Core.Repositories.Interfaces;

namespace Core.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IExceptionLogRepository ExceptionLogRepository { get; }

        IElectricityBillRepository ElectricityBillRepository { get; }

        IElectricityProviderRepository ElectricityProviderRepository { get; }

        IMobileRechargeBillRepository MobileRechargeBillRepository { get; }

        IMobileRechargeTypeRepository MobileRechargeTypeRepository { get; }

        IPaymentModeRepository PaymentModeRepository { get; }

        IPaymentRepository PaymentRepository { get; }

        IPaymentStatusRepository PaymentStatusRepository { get; }

        IServiceProviderRepository ServiceProviderRepository { get; }

        Task<int> SaveChangesAsync();
    }
}