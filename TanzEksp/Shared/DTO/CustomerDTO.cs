using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fornavn er påkrævet.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Fornavn skal være mellem 2 og 50 tegn.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Efternavn er påkrævet.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Efternavn skal være mellem 2 og 50 tegn.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email er påkrævet.")]
        [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefonnummer er påkrævet.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefonnummer skal være præcist 8 cifre.")]
        public string? PhoneNumber { get; set; }

        public List<BookingDTO>? Bookings { get; set; } = new List<BookingDTO>();
    }
}
