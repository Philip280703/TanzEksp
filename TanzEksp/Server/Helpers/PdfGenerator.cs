using QuestPDF.Fluent;
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
                page.Header().Text("Rejseplan").FontSize(20).Bold();
                page.Content().Column(col =>
                {
                    col.Item().Text($"Kunde: {Customer.FirstName}");
                    col.Item().Text($"Email: {Customer.Email}");
                    col.Item().Text($"Bestillingsdato: {DateTime.Now:dd-MM-yyyy}");

                    col.Item().PaddingTop(15).Text("Tripevents").FontSize(16).Bold();
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("Navn").Bold();
                            header.Cell().Text("Sted").Bold();
                            header.Cell().Text("Dato").Bold();
                        });

                        foreach (var evt in tripevents)
                        {
                            table.Cell().Text(evt.Title);
                            table.Cell().Text(evt.Description);
                            table.Cell().Text(evt.Days);
                        }
                    });

                    col.Item().PaddingTop(15).Text("Dagsplaner").FontSize(16).Bold();
                    foreach (var day in dayplans)
                    {
                        col.Item().Text($"{day.Title}: {day.Description}");
                    }
                });
            });
        }
    }
}
