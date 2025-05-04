using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Domain.Entities
{
    public enum TripType
    {
        Group,
        Private
    }
    public class Trip
    {
        public int Id { get; set; }

        public TripType TripType { get; set; }

        public bool IsTemplate { get; set; } = false;

        public List<TripEvent>? Events { get; set; }
    }
}
