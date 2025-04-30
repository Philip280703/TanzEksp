using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
	public interface ITripEventService
	{
		Task<List<TripEventDTO>> GetAllTripEventsAsync();
		Task<TripEventDTO> GetTripEventByIdAsync(int id);
		Task<int> AddTripEventAsync(TripEventDTO tripEventDTO);
		Task<int> UpdateTripEventAsync(TripEventDTO tripEventDTO);
		Task<int> DeleteTripEventAsync(int id);
	}
}
