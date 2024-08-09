using Coffee.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
	{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddCustomDbContext(configuration);

            return services;
        }

        private static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetValue<string>("DefaultConnectionString");

            services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(sqlConnectionString).EnableThreadSafetyChecks())
                .AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();

            return services;
        }
    }
}

