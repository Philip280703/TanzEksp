using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Domain.Entities
{
    
    public class Trip
    {
        public int Id { get; set; }

        public string TripType { get; set; }

        public List<TripEvent>? Events { get; set; }

    }
}
