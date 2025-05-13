using Microsoft.AspNetCore.Mvc;
using TanzEksp.Shared.DTO;
using TanzEksp.Server.Helpers;

namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        [HttpPost("generate")]
        public IActionResult GeneratePdf([FromBody] PdfRequestDTO request)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            var pdfBytes = PdfHelper.GenerateTripPdf(request.Customer, request.TripEvents, request.DayPlans, request.Booking);
            return File(pdfBytes, "application/pdf", "rejseplan.pdf");
        }
    }
}
