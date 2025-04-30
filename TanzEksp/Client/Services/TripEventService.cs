using System.Net.Http.Json;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
	public class TripEventService : ITripEventService
	{
		private readonly HttpClient _httpClient;

		public TripEventService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<TripEventDTO>> GetAllTripEventsAsync()
		{
			var tripEvent = await _httpClient.GetFromJsonAsync<List<TripEventDTO>>("api/TripEvent");
			if (tripEvent == null)
			{
				throw new Exception("Failed to load tripevent");
			}
			return tripEvent;
		}

		public async Task<TripEventDTO> GetTripEventByIdAsync(int id)
		{
			var tripEvent = await _httpClient.GetFromJsonAsync<TripEventDTO>($"api/TripEvent/{id}");
			if (tripEvent == null)
			{
				throw new Exception($"Failed to load tripevent with ID {id}");
			}
			return tripEvent;
		}

		public async Task<int> AddTripEventAsync(TripEventDTO tripEvent)
		{
			var answer = await _httpClient.PostAsJsonAsync("api/TripEvent",tripEvent);
			var answerCode = (int)answer.StatusCode;
			return answerCode;
		}

		public async Task<int> UpdateTripEventAsync(TripEventDTO tripEvent)
		{
			var answer = await _httpClient.PutAsJsonAsync($"api/TripEvent/{tripEvent.Id}", tripEvent);
			var answerCode = (int)answer.StatusCode;
			return answerCode;
		}

		public async Task<int> DeleteTripEventAsync(int id)
		{
			var answer = await _httpClient.DeleteAsync($"api/TripEvent/{id}");
			var answerCode = (int)answer.StatusCode;
			return answerCode;
		}


	}
}
