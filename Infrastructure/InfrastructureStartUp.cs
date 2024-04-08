using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureStartUp
    {
        public static IServiceCollection TryAddInfrastructure(this IServiceCollection services)
        {
            services.TryAddScoped<IdentityContext, IdentityContext>();
            //services.TryAddScoped<IRepository<User>, UserRepository>();
            //services.TryAddScoped<IRepository<Team>, TeamRepository>();
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
