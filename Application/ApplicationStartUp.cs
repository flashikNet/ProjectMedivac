using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Application
{
    public static class ApplicationStartUp
    {
        public static IServiceCollection TryAddApplication(this IServiceCollection services)
        {
            services.TryAddScoped<IIdentityService, IdentityService>();
            services.TryAddScoped<IInviteService, InviteService>();
            services.TryAddScoped<ITeamService, TeamService>();
            return services;
        }
    }
}
