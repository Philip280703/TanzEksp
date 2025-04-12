using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerUseCase _customerUseCase;

        public CustomerController(CustomerUseCase customerUseCase)
        {
            _customerUseCase = customerUseCase;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerUseCase.GetAll();
            return Ok(customers);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var customer = _customerRepository.GetById(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customer);
        //}

        //[HttpPost]
        //public IActionResult Add([FromBody] Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return BadRequest();
        //    }
        //    _customerRepository.Add(customer);
        //    return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] Customer customer)
        //{
        //    if (id != customer.Id || customer == null)
        //    {
        //        return BadRequest();
        //    }
        //    _customerRepository.Update(customer);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var customer = _customerRepository.GetById(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    _customerRepository.Delete(id);
        //    return NoContent();
        //}
    }
}
