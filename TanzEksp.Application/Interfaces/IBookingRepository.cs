using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingById(Guid id);
        Task<List<Booking>> GetAllBookings();
        Task AddBooking(Booking booking);
        Task UpdateBooking(Booking booking);
        Task DeleteBooking(Guid id);
    }
}
