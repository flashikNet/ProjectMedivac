using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure
{
    public static class InfrastructureStartUp
    {
        public static IServiceCollection TryAddInfrastructure(this IServiceCollection services)
        {
            services.TryAddScoped<ITeamsRepository, TeamsRepository>();
            services.TryAddScoped<IUsersRepository, UsersRepository>();
            services.TryAddScoped<IDuelsRepository, DuelsRepository>();
            return services;
        }
    }
}
