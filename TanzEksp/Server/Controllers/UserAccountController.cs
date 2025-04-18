using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountUseCase _userAccountUseCase;

        public UserAccountController(UserAccountUseCase userAccountUseCase)
        {
            _userAccountUseCase = userAccountUseCase;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userAccountUseCase.GetAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userAccountUseCase.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserAccount user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            Task task = _userAccountUseCase.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserAccount user)
        {
            if (id != user.Id || user == null)
            {
                return BadRequest();
            }
            Task task = _userAccountUseCase.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userAccountUseCase.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            Task task = _userAccountUseCase.Delete(id);
            return NoContent();
        }
    }
}
