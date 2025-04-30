using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.UseCases
{
    public class BookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> GetBookingById(Guid id)
        {
            return await _bookingRepository.GetBookingById(id);
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _bookingRepository.GetAllBookings();
        }

        public async Task Add(Booking booking)
        {
            await _bookingRepository.AddBooking(booking);
        }

        public async Task Update(Booking booking)
        {
            await _bookingRepository.UpdateBooking(booking);
        }

        public async Task Delete(Guid id)
        {
            await _bookingRepository.DeleteBooking(id);
        }   
    }
}
