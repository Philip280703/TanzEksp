using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Client.Services;

namespace TanzEksp.Client.DI
{
    public static class ClientCollection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<ICustomerService, CustomerService>();


            return services;
        }
    }
}
