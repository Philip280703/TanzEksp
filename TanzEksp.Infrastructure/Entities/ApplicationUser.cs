using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;   
    }
}
