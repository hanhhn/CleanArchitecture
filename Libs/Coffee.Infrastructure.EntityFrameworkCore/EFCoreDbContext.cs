using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Coffee.Infrastructure.EntityFrameworkCore
{
    public class EFCoreDbContext : DbContext
    {
        public static readonly ILoggerFactory DbLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        public EFCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(DbLoggerFactory).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

