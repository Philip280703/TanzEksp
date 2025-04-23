using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Application.Login
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
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }

    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
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
