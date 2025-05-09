using QuestPDF.Fluent;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Server.Helpers
{
    public static class PdfHelper
    {
        public static byte[] GenerateTripPdf(CustomerDTO customer, List<TripEventDTO> events, List<DayPlanDTO> plans)
        {
            var pdf = new PdfGenerator(customer, events, plans);
            return pdf.GeneratePdf();
        }
    }
}
