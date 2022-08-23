using Contacts_List.Application.Interfaces;
using Contacts_List.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts_List.Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            
            return services;
        }
    }
}
