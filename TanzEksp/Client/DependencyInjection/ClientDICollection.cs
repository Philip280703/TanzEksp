using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Client.Services;

namespace TanzEksp.Client.DI
{
    public static class ClientDICollection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<ICustomerService, CustomerService>();


            return services;
        }
    }
}
