using Core.DataAccessLayer;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;
using Core.Webapi.Services;
using Core.Webapi.Services.Interfaces;

namespace Core.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration.GetSection("Jwt")["Issuer"],
                        ValidAudience = Configuration.GetSection("Jwt")["Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt")["Key"]))
                    };
                });

            //Dependencies
            services.AddScoped<CoreContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();

            services.AddScoped<IMobileRechargeBillRepository, MobileRechargeBillRepository>();
            services.AddScoped<IMobileRechargeTypeRepository, MobileRechargeTypeRepository>();
            services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();

            services.AddScoped<IElectricityBillRepository, ElectricityBillRepository>();
            services.AddScoped<IElectricityProviderRepository, ElectricityProviderRepository>();

            services.AddScoped<IPaymentModeRepository, PaymentModeRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();

            services.AddScoped<ILinkPaymentsMobileRechargeRepository, LinkPaymentsMobileRechargeRepository>();
            services.AddScoped<ILinkPaymentsElectricityBillRepository, LinkPaymentsElectricityBillRepository>();

            services.AddScoped<IMobileRechargeService, MobileRechargeService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IJwtTokenService, JwtTokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
