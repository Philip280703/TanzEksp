using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace TanzEksp.Domain.Entities
    {
    public class DayPlan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Dato er påkrævet")]
        [StringLength(50, ErrorMessage = "Title må max være 10 tegn")]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Accommodation { get; set; }

        public string? Meals { get; set; }

        public int TripEventId { get; set; }
    }
}
