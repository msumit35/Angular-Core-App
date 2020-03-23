using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.DataAccessLayer
{
    public class CoreContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetSection("AppSettings")["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<LinkPaymentMobileRechargeBill>().ToTable("Link_Payments_MobileRechargeBills");
            mb.Entity<LinkPaymentElectricityBills>().ToTable("Link_Payments_ElectricityBills");
            mb.Entity<PaymentStatus>().ToTable("PaymentStatuses");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public DbSet<ElectricityBill> ElectricityBills { get; set; }

        public DbSet<ElectricityProvider> ElectricityProviders { get; set; }

        public DbSet<LinkPaymentElectricityBills> LinkPaymentsElectricityBills { get; set; }

        public DbSet<LinkPaymentMobileRechargeBill> LinkPaymentsMobileRechargeBills { get; set; }

        public DbSet<MobileRechargeType> MobileRechargeTypes { get; set; }

        public DbSet<MobileRechargeBill> MobileRechargeBills { get; set; }

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<PaymentMode> PaymentModes { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<ServiceProvider> ServiceProviders { get; set; }
    }
}
