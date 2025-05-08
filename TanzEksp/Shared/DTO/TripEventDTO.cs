using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
	public class TripEventDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Title er påkrævet")]
		[StringLength(100, ErrorMessage = "Title må max være 100 tegn")]
		public string? Title { get; set; }

		public string? Description { get; set; }

		[Required(ErrorMessage = "Antal dage er påkrævet")]
		[Range(1, 30, ErrorMessage = "Antal dage skal være mellem 1 og 30")]
		public int Days { get; set; } = 1;

		[Required(ErrorMessage = "Standart pris er påkrævet")]
		[Range(0, 100000, ErrorMessage = "Standart pris skal være mellem 0 og 100000")]
		public decimal? Price { get; set; }

		public int ?TripId { get; set; }

		public bool IsTemplate { get; set; } = false;

		public int ?Priority { get; set; } 

        public List<DayPlanDTO>? DayPlans { get; set; }
    }
}
