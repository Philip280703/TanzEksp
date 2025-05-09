using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Client.Services;

namespace TanzEksp.Client.DI
{
    public static class ClientDICollection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<UserService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IDayPlanService, DayPlanService>();
            services.AddScoped<ITripEventService, TripEventService>();
            return services;
        }
    }
}
