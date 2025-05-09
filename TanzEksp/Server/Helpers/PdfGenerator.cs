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

        public PdfGenerator(CustomerDTO customer, List<TripEventDTO> tripEvents, List<DayPlanDTO> dayPlans)
        {
            Customer = customer;
            tripevents = tripEvents;
            dayplans = dayPlans;

        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;


        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);

                var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "img", "logo.png");

                page.Header().Row(row =>
                {
                    row.RelativeItem().Text("Rejseplan").FontSize(20).Bold();
                    row.ConstantItem(100).Height(60).Image(logoPath, ImageScaling.FitArea);
                });

                page.Content().Column(col =>
                {
                    // Kundeoplysninger
                    col.Item().Text($"Kunde: {Customer.FirstName}");
                    col.Item().Text($"Email: {Customer.Email}");
                    col.Item().Text($"Bestillingsdato: {DateTime.Now:dd-MM-yyyy}");

                    col.Item().PaddingVertical(20);

                    foreach (var evt in tripevents)
                    {
                        // Eventtitel
                        col.Item().Text($"{evt.Title}").FontSize(16).Bold();
                        col.Item().Text($"Antal dage: {evt.Days}").Italic();
                        col.Item().Text(evt.Description);
                        col.Item().PaddingBottom(10);

                        // Dagsplaner
                        var relatedDayPlans = dayplans
                            .Where(d => d.TripEventId == evt.Id)
                            .ToList();

                        if (relatedDayPlans.Any())
                        {
                            col.Item().Text("Dagsplaner").FontSize(14).Bold();

                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(40); // Dag
                                    columns.RelativeColumn();   // Beskrivelse
                                });

                                // Tabel-header med farve
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Blue.Darken2).Padding(5).Text("Dag").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Blue.Darken2).Padding(5).Text("Beskrivelse").FontColor(Colors.White).Bold();
                                });

                                int dayIndex = 1;
                                foreach (var day in relatedDayPlans)
                                {
                                    table.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text($"{dayIndex++}");
                                    table.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text(day.Description);
                                }
                            });

                            // Separator mellem tripevents
                            col.Item().PaddingVertical(20).LineHorizontal(1).LineColor(Colors.Brown.Medium);
                        }
                    }
                });

                
            });
        }



    }
}
