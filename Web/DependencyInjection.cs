using Coffee.Constants;
using Coffee.Infrastructure.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.EntityFramework.DbContext;
using Infrastructure.Repositories;
using Web.Infrastructure;
using Web.Services;

namespace Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services
                .AddRepositories()
                .AddServices()
                .AddHttpServices()
                .AddApiVersioning()
                .AddExceptionHandler<ApplicationExceptionHandler>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityContext, IdentityService>();

            return services;
        }

        private static IServiceCollection AddHttpServices(this IServiceCollection services)
        {

            return services;
        }

        private static IServiceCollection AddApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }


        public static WebApplication EnsureCreated(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            return app;
        }

        public static ConfigurationManager ConfigureAppConfiguration(this ConfigurationManager configuration, IWebHostEnvironment env)
        {
            configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, false)
                .AddEnvironmentVariables();

            AppSettings.Configs = configuration;
            AppSettings.Instance = AppSettings.Configs.GetSection("AppSettings").Get<AppSettings>();
            return configuration;
        }
    }
}

