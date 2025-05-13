using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
    public interface IPdfService
    {
        Task DownloadTripPdfAsync(CustomerDTO customer, List<TripEventDTO> events, List<DayPlanDTO> plans, BookingDTO booking);
    }
}
