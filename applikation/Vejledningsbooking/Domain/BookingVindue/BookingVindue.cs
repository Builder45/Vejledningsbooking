using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class BookingVindue
    {
        [Column(Order = 0)]
        public int BookingVindueId { get; set; }
        [Column(Order = 1)]
        public DateTime StartTidspunkt { get; set; }
        [Column(Order = 2)]
        public DateTime SlutTidspunkt { get; set; }

        public int? UnderviserId { get; set; }
        public int? HoldId { get; set; }
        public virtual Kalender Kalender { get; set; }

        public virtual ICollection<Booking> Bookinger { get; set; }


        public void AddBooking(Booking booking)
        {
            if (booking.PasserMedVindue(this) == false)
            {
                throw new ArgumentOutOfRangeException("Fejl: Booking udenfor tidsrammen");
            }

            foreach (var eksisterendeBooking in Bookinger)
            {
                if (booking.HarOverlap(eksisterendeBooking))
                {
                    throw new ArgumentOutOfRangeException("Fejl: Booking overlapper anden booking");
                }
            }

            Bookinger.Add(booking);
        }
    }
}
