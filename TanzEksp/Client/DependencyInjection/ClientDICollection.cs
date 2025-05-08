using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Client.Services;

namespace TanzEksp.Client.DI
{
    public static class ClientDICollection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<TripService>();
            services.AddScoped<UserService>();
            services.AddScoped<CustomerService>(); // Den vil ikke køre medmindre jeg tilføjer customerService. Underligt når vi har AddClientServices. 
            services.AddScoped<BookingService>();
            services.AddScoped<DayPlanService>();
            services.AddScoped<TripEventService>();
            services.AddScoped<IPdfService, PdfService>();
            return services;
        }
    }
}
