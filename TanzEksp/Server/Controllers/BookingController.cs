using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.Interfaces;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class BookingController : ControllerBase
    {
        private readonly BookingUseCase _bookingUseCase;

        public BookingController(BookingUseCase bookingUseCase)
        {
            _bookingUseCase = bookingUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingUseCase.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetBookingById(Guid bookingId)
        {
            var bookings = await _bookingUseCase.GetBookingById(bookingId);
            if (bookings == null)
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }

            await _bookingUseCase.Add(booking);
            return CreatedAtAction(nameof(GetBookingById), new { bookingId = booking.Id }, booking);
        }

        [HttpDelete("{bookingid}")]
        public async Task<IActionResult> Delete(Guid bookingid)
        {
            var customer = await _bookingUseCase.GetBookingById(bookingid);
            if (customer == null)
            {
                return NotFound();
            }
            await _bookingUseCase.Delete(bookingid);
            return NoContent();
        }
    }
}
