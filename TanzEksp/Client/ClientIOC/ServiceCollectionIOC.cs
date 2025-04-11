using Microsoft.Extensions.DependencyInjection;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Client.Services;

namespace TanzEksp.Client.ClientIOC
{
    public static class ServiceCollectionIOC
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<ICustomerService, CustomerService>();
           

            return services;
        }
    }
}
