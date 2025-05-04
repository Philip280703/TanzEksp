using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
	public interface IBookingService
	{
		Task<BookingDTO> GetBookingByIdAsync(Guid id);
		Task<List<BookingDTO>> GetAllBookingsAsync();
		Task<int> AddBookingAsync(BookingDTO booking);
		Task<int> UpdateBookingAsync(BookingDTO booking);
		Task<int> DeleteBookingAsync (Guid id);
	}
}
