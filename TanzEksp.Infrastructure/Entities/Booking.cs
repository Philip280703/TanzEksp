using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Domain.Entities
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; } 

        public Guid CustomerId { get; set; }

        public int ?TripId { get; set; }

        [Required(ErrorMessage = "Antal voksne er påkrævet")]
        [Range(1, 10, ErrorMessage = "Antal voksne skal være mellem 1 og 10")]
        public int AdultCount { get; set; }

        [Range(0, 10, ErrorMessage = "Antal børn skal være mellem 0 og 10")]
        public int? ChildCount { get; set; }

        public string? Airport { get; set; }

        public string? TripLength { get; set; }

        public string? Status { get; set; }

        public DateTime? DepartureDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Customer? Customer { get; set; }

        public Trip? Trip { get; set; }


   
    }
}
