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

        public DbSet<User> Users { get; set; }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}
