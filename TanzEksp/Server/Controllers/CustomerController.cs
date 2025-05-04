using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerUseCase _customerUseCase;

        public CustomerController(CustomerUseCase customerUseCase)
        {
            _customerUseCase = customerUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerUseCase.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerUseCase.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            await _customerUseCase.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Customer customer)
        {
            if (id != customer.Id || customer == null)
            {
                return BadRequest();
            }
            await _customerUseCase.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerUseCase.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerUseCase.Delete(id);
            return NoContent();
        }
    }
}
