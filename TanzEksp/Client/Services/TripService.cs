using System.Net.Http.Json;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
    public class TripService : ITripService
    {
        private readonly HttpClient _httpClient;

        public TripService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TripDTO>> GetAllTripsAsync()
        {
            var trips = await _httpClient.GetFromJsonAsync<List<TripDTO>>("api/trip");
            if (trips == null)
            {
                throw new Exception("Failed to load trips");
            }
            return trips;
        }

        public async Task<TripDTO> GetTripByIdAsync(int id)
        {
            var trip = await _httpClient.GetFromJsonAsync<TripDTO>($"api/trip/{id}");
            if (trip == null)
            {
                throw new Exception($"Failed to load trip with ID {id}");
            }
            return trip;
        }

        public async Task<int> AddTripAsync(TripDTO trip)
        {
            var answer = await _httpClient.PostAsJsonAsync("api/trip", trip);
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }

        // TODO - måske lave update og delete, finder vi ud af på fredag :-) 
    }
}
