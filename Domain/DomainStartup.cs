using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class DomainStartup
    {
        public static IServiceCollection TryAddDomain(this IServiceCollection services)
        {
            services.TryAddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}
