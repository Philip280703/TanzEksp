using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Domain.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Fornavn er påkrævet")]
        [StringLength(50, ErrorMessage = "Fornavn må højst være 50 tegn")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Efternavn er påkrævet")]
        [StringLength(50, ErrorMessage = "Efternavn må højst være 50 tegn")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email er påkrævet")]
        [EmailAddress(ErrorMessage = "Ugyldig emailadresse")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefonnummer er påkrævet")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Telefonnummer skal være mellem 8 og 10 cifre")]
        [Phone(ErrorMessage = "Ugyldigt telefonnummerformat")]
        public string PhoneNumber { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public List<Booking>? Bookings { get; set; } = new List<Booking>();


       
    }
}
