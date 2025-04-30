using System.Net.Http.Json;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
	public class BookingService : IBookingService
	{
		private readonly HttpClient _httpClient;

		public BookingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<BookingDTO>> GetAllBookingsAsync()
		{
			var bookings = await _httpClient.GetFromJsonAsync<List<BookingDTO>>("api/booking");
			if (bookings == null)
			{
				throw new Exception("Failed to load bookings");
			}
			return bookings;
		}

		public async Task<BookingDTO> GetBookingByIdAsync(Guid id)
		{
			var booking = await _httpClient.GetFromJsonAsync<BookingDTO>($"api/booking/{id}");
			if (booking == null)
			{
				throw new Exception($"Failed to load booking with ID {id}");
			}
			return booking;
		}

		public async Task<int> AddBookingAsync(BookingDTO booking)
		{
			var answer = await _httpClient.PostAsJsonAsync("api/booking", booking);
			var answerCode = (int)answer.StatusCode;
			return answerCode;
		}

        public async Task<int> UpdateBookingAsync(BookingDTO booking)
        {
            var answer = await _httpClient.PutAsJsonAsync($"api/booking/{booking.Id}", booking);
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }

        public async Task<int> DeleteBookingAsync(Guid id)
		{
			var answer = await _httpClient.DeleteAsync($"api/booking/{id}");
			var answerCode = (int)answer.StatusCode;
			return answerCode;
		}
	}
}

