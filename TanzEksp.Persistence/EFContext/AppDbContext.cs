using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanzEksp.Shared.Domain;

namespace TanzEksp.Persistence.EFContext
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TanzEksp;Trusted_Connection=True;");
        }

        public DbSet<Booking> BookingEF { get; set; }
        public DbSet<TripEvent> TripEventEF { get; set; } 
        public DbSet<Customer> CustomerEF { get; set; }
        public DbSet<DayPlan> DayPlanEF { get; set; }
        public DbSet<EmployeeUser> EmployeeUserEF { get; set; }
        public DbSet<Trip> TripEF { get; set; }
        public DbSet<Zipcode> ZipcodeEF { get; set; }

      
    }
}
