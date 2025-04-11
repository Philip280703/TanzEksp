using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.Domain
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Antal voksne er påkrævet")]
        [Range(1, 10, ErrorMessage = "Antal voksne skal være mellem 1 og 10")]
        public int AdultCount { get; set; }

        [Range(0, 10, ErrorMessage = "Antal børn skal være mellem 0 og 10")]
        public int? ChildCount { get; set; }



        public Customer? Customer { get; set; }

    }
}
