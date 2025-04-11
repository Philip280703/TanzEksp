using Microsoft.Extensions.DependencyInjection;
using TanzEksp.Server.RepositoryInterfaces;


namespace TanzEksp.Server.ServerIOC
{
    public static class ServiceCollectionIOCServer
    {
        public static IServiceCollection AddServerServices(this IServiceCollection services)
        {
            //// Register IOC service her
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICustomerRepository, CustomerRepositorySQL>();

            return services;
        }
    }
}
