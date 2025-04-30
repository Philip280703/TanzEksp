using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Shared.DTO
{
    public enum TripType
    {
        Group,
        Private
    }

    public class TripDTO
    {
        public int Id {  get; set; }
        public TripType TripType { get; set; }
        public bool IsTemplate { get; set; } = false;       
    }
}
