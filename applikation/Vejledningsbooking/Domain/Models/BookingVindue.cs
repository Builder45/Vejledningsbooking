﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class BookingVindue
    {
        public int Id { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        //public int? KalenderId { get; set; }
        public Underviser Underviser { get; set; }
        public Kalender Kalender { get; set; }
        public ICollection<Booking> Bookinger { get; set; }
    }
}
