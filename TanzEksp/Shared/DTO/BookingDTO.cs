using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? TripId { get; set; }
        public int AdultCount { get; set; }
        public int? ChildCount { get; set; }
        public string? Airport { get; set; }
        public string? TripLength { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string ?Status { get; set; }
        public CustomerDTO? Customer { get; set; }

        public TripDTO? Trip { get; set; }

    }
}
