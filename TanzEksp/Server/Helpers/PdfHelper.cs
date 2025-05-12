using QuestPDF.Fluent;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Server.Helpers
{
    public static class PdfHelper
    {
        public static byte[] GenerateTripPdf(CustomerDTO customer, List<TripEventDTO> events, List<DayPlanDTO> plans, BookingDTO booking)
        {
            var pdf = new PdfGenerator(customer, events, plans, booking);
            return pdf.GeneratePdf();
        }
    }
}
