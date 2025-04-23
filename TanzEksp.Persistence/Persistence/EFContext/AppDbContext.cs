using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanzEksp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TanzEksp.Infrastructure.Persistence.EFContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> BookingEF { get; set; }
        public DbSet<TripEvent> TripEventEF { get; set; }
        public DbSet<Customer> CustomerEF { get; set; }
        public DbSet<DayPlan> DayPlanEF { get; set; }
        public DbSet<Trip> TripEF { get; set; }
       


    }
}
