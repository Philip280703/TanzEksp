using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
    public class PdfRequestDTO
    {
        public CustomerDTO Customer { get; set; } = default!;
        public List<TripEventDTO> TripEvents { get; set; } = new();
        public List<DayPlanDTO> DayPlans { get; set; } = new();
        public BookingDTO Booking { get; set; } = default!;
    }
}
