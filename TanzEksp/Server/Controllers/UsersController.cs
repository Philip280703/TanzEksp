using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.Login;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = _userManager.Users.ToList();
            var result = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result.Add(new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FullName = user.FullName,
                    Role = roles.FirstOrDefault() ?? "User"
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    FullName = model.FullName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return BadRequest("Create failed: " + errors);
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleResult.Succeeded)
                {
                    var roleErrors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return BadRequest("Role failed: " + roleErrors);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Undtagelse: {ex.Message}");
            }
        } 
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto model)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = model.Username,
        //        FullName = model.FullName
        //    };

        //    var roleResult = await _userManager.AddToRoleAsync(user, "User");
        //    if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);


        //    await _userManager.AddToRoleAsync(user, "User");
        //    return Ok();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.FullName = dto.FullName;
            await _userManager.UpdateAsync(user);

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, dto.Role);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            return NoContent();
        }
    }
}
