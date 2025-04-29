using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
    public interface ITripService
    {
        Task<List<TripDTO>> GetAllTripsAsync();
        Task<TripDTO?> GetTripByIdAsync(int id);
        Task<int> AddTripAsync(TripDTO trip);
        //Task<int> RemoveTripAsync(int id);
    }
}
