using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
	public interface IBookingService
	{
		Task<BookingDTO> GetBookingById(int id);
		Task<List<BookingDTO>> GetAllBookings();
		Task<int> AddBookingAsync(BookingDTO booking);
		Task<int> UpdateBookingAsync(BookingDTO booking);
		Task<int> DeleteBookingAsync (BookingDTO booking);
	}
}
