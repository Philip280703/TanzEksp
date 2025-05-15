using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Server.Helpers
{
    public class PdfGenerator : IDocument
    {
        private readonly CustomerDTO Customer;
        private readonly List<TripEventDTO> tripevents;
        private readonly List<DayPlanDTO> dayplans;
        private readonly BookingDTO booking;

        int dayCount = 1;

        public PdfGenerator(CustomerDTO customer, List<TripEventDTO> tripEvents, List<DayPlanDTO> dayPlans, BookingDTO Booking)
        {
            Customer = customer;
            tripevents = tripEvents;
            dayplans = dayPlans;
            booking = Booking;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;


        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Rejseplanen til dit livs oplevelse").FontSize(20).Bold().FontColor(Colors.Orange.Medium);
                        col.Item().Text($"Booking Nr: {booking.Id}").FontSize(10).FontColor(Colors.Grey.Darken2);
                    });

                    var basePath = AppContext.BaseDirectory;
                    var logoPath = Path.Combine(basePath, "Resources", "logo.png");

                    row.ConstantItem(100).Height(60).Image(logoPath, ImageScaling.FitArea);
                });

                page.Content().Column(col =>
                {
                    // Kundeoplysninger
                    col.Item().PaddingBottom(10).Text($"Kunde: {Customer.FirstName} {Customer.LastName}").FontSize(12);
                    col.Item().Text($"Email: {Customer.Email}").FontSize(12);
                    col.Item().Text($"Antal: {booking.AdultCount} + {booking.ChildCount}").FontSize(12);
                    col.Item().Text($"Tilbud genereret: {DateTime.Now:dd. MMMM yyyy}").FontSize(12);

                    col.Item().PaddingVertical(20).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    foreach (var evt in tripevents)
                    {

                       
                        col.Item().Text($"Rejse: {evt.Title}")
                            .FontSize(16).Bold().FontColor(Colors.Orange.Darken1);

                        col.Item().Container().PaddingBottom(10)
                        .Text(evt.Description ?? "Beskrivelse ikke angivet").FontSize(12);


                        var relatedDayPlans = dayplans.Where(d => d.TripEventId == evt.Id).ToList();

                        if (relatedDayPlans.Any())
                        {
                            foreach (var day in relatedDayPlans)
                            {
                                col.Item().PaddingBottom(5).Column(dayCol =>
                                {
                                    dayCol.Item().Text($"Dag {dayCount}: {day.Title}").Bold().FontSize(12).FontColor(Colors.Orange.Accent2);
                                    dayCol.Item().Text(day.Description).FontSize(11);
                                    if (!string.IsNullOrWhiteSpace(day.Meals))
                                        dayCol.Item().Container().PaddingTop(5).Text($"Måltider: {day.Meals}").FontSize(12).Italic();
                                    if (!string.IsNullOrWhiteSpace(day.Accommodation))
                                        dayCol.Item().Container().PaddingTop(5).Text($"Overnatning: {day.Accommodation}").FontSize(12).Italic();

                                    dayCount++;
                                });
                            }
                        }

                        col.Item().PaddingVertical(10).LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten1);
                    }

                    // Pris og noter
                    col.Item().PaddingTop(20).Text("Samlet pris for jeres rejse").FontSize(14).Bold();
                    col.Item().Text($"Pris pr. voksen: {CalculateSum():N0} kr.")
                              .FontSize(14).FontColor(Colors.Green.Darken2).Bold();

                    // Takkeafsnit
                    col.Item().PaddingTop(25).Text("Tak for din interesse i at planlægge dit næste store eventyr med os!")
                              .FontSize(12).Italic().FontColor(Colors.Grey.Darken2);
                });
            });
        }


        private decimal CalculateSum()
        {
            decimal? sum = 0;
            foreach(var tripevent in tripevents)
            {
                sum += tripevent.Price;
            }
            return sum.Value;
        }

    }
}
