using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class BookingVindue
    {
        public int BookingVindueId { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        public virtual ICollection<Booking> Bookinger { get; set; }
        public int? KalenderId { get; set; }
        public virtual Kalender Kalender { get; set; }



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
