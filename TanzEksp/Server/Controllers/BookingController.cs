using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.Interfaces;
using TanzEksp.Application.UseCases;
using TanzEksp.Domain.Entities;
using TanzEksp.Shared.DTO;

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

        private Booking convert(BookingDTO bookingDTO)
        {
            return new Booking
            {
                Id = bookingDTO.Id,
                CustomerId = bookingDTO.CustomerId,
                AdultCount = bookingDTO.AdultCount,
                ChildCount = bookingDTO.ChildCount,
                Airport = bookingDTO.Airport,
                DepartureDate = bookingDTO.DepartureDate,
                TripLength = bookingDTO.TripLength,
                TripId = bookingDTO.TripId
            };
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
        public async Task<IActionResult> Add([FromBody] BookingDTO booking)
        {
            var _booking = convert(booking);
            if (booking == null)
            {
                return BadRequest();
            }

            await _bookingUseCase.Add(_booking);
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

        [HttpPut("{bookingId}")]
        public async Task<IActionResult> Update(Guid bookingId, [FromBody] BookingDTO booking)
        {
            if (booking == null || bookingId != booking.Id)
            {
                return BadRequest();
            }
            var existingBooking = await _bookingUseCase.GetBookingById(bookingId);
            if (existingBooking == null)
            {
                return NotFound();
            }
            var _booking = convert(booking);
            await _bookingUseCase.Update(_booking);
            return NoContent();
        }
    }
}
