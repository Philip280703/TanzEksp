using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Auth;
using TanzEksp.Application.Interfaces;
using TanzEksp.Application.Auth;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Infrastructure.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<LoginResult?> LoginAsync(LoginCommand command)
        {
           var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, command.Password, false);
            if(!result.Succeeded) return null;

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new LoginResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }

        public async Task<RegisterResult> RegisterAsync(RegisterCommand command)
        {
            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email
            };

            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                return new RegisterResult
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

            // Tildel rolle (default = "User")
            if (!await _roleManager.RoleExistsAsync(command.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(command.Role));
            }

            await _userManager.AddToRoleAsync(user, command.Role);

            return new RegisterResult { Success = true };
        }

    }
}
