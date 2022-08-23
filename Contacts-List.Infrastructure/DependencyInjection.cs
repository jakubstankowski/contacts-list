using Contacts_List.Application.Interfaces;
using Contacts_List.Application.Services;
using Contacts_List.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts_List.Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IContext>(provider => provider.GetService<Context>());
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IContactService, ContactService>();

            return services;
        }
    }
}
