﻿using System.Reflection;
using Coffee.Application.Behaviours;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
	{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviour<>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            });

            return services;
        }
    }
}

