using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class TripController : ControllerBase
    {
        private readonly TripUseCase _TripUseCase;

        public TripController(TripUseCase tripUseCase)
        {
            _TripUseCase = tripUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trips = await _TripUseCase.GetAll();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trip = await _TripUseCase.GetById(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Trip trip)
        {
            if (trip == null)
            {
                return BadRequest();
            }
            await _TripUseCase.Add(trip);
            return CreatedAtAction(nameof(GetById), new { id =  trip.Id });
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var trip = await _TripUseCase.GetById(id);
        //    if (trip == null)
        //    {
        //        return NotFound();
        //    }
        //    await _TripUseCase.Delete(id);
        //    return NoContent();
        //}
    }
}
