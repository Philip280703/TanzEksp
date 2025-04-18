﻿using System;
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

        public DateTime? StartDate { get; set; }

        public TripType TripType { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }

        public List<TripEvent>? Events { get; set; }
    }
}
