using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.Login
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }

    public class RegisterDto
    {
        [Required(ErrorMessage = "Brugernavn er påkrævet")]
        [EmailAddress(ErrorMessage = "Brugernavn skal være en gyldig e-mailadresse.")]
        public string Username { get; set; }
       
        [Required(ErrorMessage = "Password er påkrævet.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{10,}$",
         ErrorMessage = "Adgangskoden skal være mindst 10 tegn og indeholde mindst ét stort bogstav, ét lille bogstav, ét tal og ét specialtegn.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "fullname er påkrævet")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "fullname must be between 8 and 50 characters.")]
        public string FullName { get; set; }
    }

    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
       
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class JwtResponse
    {
        public string Token { get; set; }
    }
}
