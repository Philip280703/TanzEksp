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
        public int Id { get; set; }

        [Required(ErrorMessage = "Fornavn er påkrævet.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Efternavn er påkrævet.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email er påkrævet.")]
        [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefonnummer er påkrævet.")]
        [Phone(ErrorMessage = "Indtast et gyldigt telefonnummer.")]
        public string? PhoneNumber { get; set; }
    }
}
