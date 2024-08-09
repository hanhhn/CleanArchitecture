using System.Reflection;
using Domain.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.DbContext
{
    public class ApplicationDbContext : EFCoreDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Post> Posts { get; set; }
    }
}

