using Microsoft.Extensions.DependencyInjection;
using TanzEksp.Application.Interfaces;
using TanzEksp.Infrastructure.Persistence.Repositories;


namespace TanzEksp.Server.ServerIOC
{
    public static class ServerDICollection
    {
        public static IServiceCollection AddServerServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepositorySQL>();
            services.AddScoped<IUserAccountRepository, UserAccountRepositorySql>();

            return services;
        }
    }
}
