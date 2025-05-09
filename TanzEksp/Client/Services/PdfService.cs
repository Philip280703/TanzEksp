using BlazorDownloadFile;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
    public class PdfService : IPdfService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private readonly IBlazorDownloadFileService _blazorDownloadFileService;

        public PdfService(HttpClient http, IJSRuntime js, IBlazorDownloadFileService blazorDownloadFileService)
        {
            _http = http;
            _js = js;
            _blazorDownloadFileService = blazorDownloadFileService;
        }

        public async Task DownloadTripPdfAsync(CustomerDTO customer, List<TripEventDTO> events, List<DayPlanDTO> plans)
        {
            var request = new
            {
                Customer = customer,
                TripEvents = events,
                DayPlans = plans
            };



            var response = await _http.PostAsJsonAsync("api/pdf/generate", request);

            if (response.IsSuccessStatusCode)
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                await _js.InvokeVoidAsync("BlazorDownloadFile", "rejseplan.pdf", "application/pdf", bytes);
            }
        }
    }
}
