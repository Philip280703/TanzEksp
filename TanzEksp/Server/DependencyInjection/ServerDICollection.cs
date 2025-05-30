﻿using Microsoft.Extensions.DependencyInjection;
using TanzEksp.Application.Interfaces;
using TanzEksp.Application.UseCases;
using TanzEksp.Infrastructure.Persistence.Repositories;


namespace TanzEksp.Server.ServerIOC
{
    public static class ServerDICollection
    {
        public static IServiceCollection AddServerServices(this IServiceCollection services)
        {
            // Register IOC service her
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITripRepository, TripRepositorySQL>();
            services.AddScoped<TripUseCase>();

            services.AddScoped<ICustomerRepository, CustomerRepositorySQL>(); 
            services.AddScoped<CustomerUseCase>();

            services.AddScoped<IBookingRepository, BookingRepositorySQL>(); 
            services.AddScoped<BookingUseCase>();

            services.AddScoped<ITripEventRepository, TripEventRepositorySql>();
            services.AddScoped<TripEventUseCase>();

            services.AddScoped<IDayPlanRepository, DayPlanRepositorySQL>();
            services.AddScoped<DayPlanUseCase>();

            return services;
        }
    }
}
