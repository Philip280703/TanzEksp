using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
    public class DayPlanDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Accommodation { get; set; }

        public string? Meals { get; set; }

    }
}
