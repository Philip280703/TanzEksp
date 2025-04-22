using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Application.Auth
{
    public class RegisterCommand
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public string Role { get; set; } = "User";
    }
}
