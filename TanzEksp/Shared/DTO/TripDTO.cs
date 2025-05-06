using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
    

    public class TripDTO
    {
        public int Id {  get; set; }
        public string TripType { get; set; }
        public List<TripEventDTO>? Events { get; set; }
    }
}
