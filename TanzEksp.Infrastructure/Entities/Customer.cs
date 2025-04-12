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
        public int Id { get; set; }


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


        [Required(ErrorMessage = "Adresse er påkrævet")]
        [StringLength(100, ErrorMessage = "Adresse må højst være 100 tegn")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Husnummer er påkrævet")]
        [StringLength(10, ErrorMessage = "Husnummer må højst være 10 tegn")]
        public string HouseNumber { get; set; }


        [Required(ErrorMessage = "Postnummer er påkrævet")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postnummer skal være 4 cifre")]
        public string Zipcode { get; set; }


        public List<Booking>? Bookings { get; set; } = new List<Booking>();


        public Zipcode? ZipcodeDetails { get; set; }
    }
}
