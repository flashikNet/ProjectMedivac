﻿using Domain.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application
{
    public static class ApplicationStartUp
    {
        public static IServiceCollection TryAddApplication(this IServiceCollection services)
        {
            services.AddSingleton(new TokenService());
            return services;
        }
    }
}
