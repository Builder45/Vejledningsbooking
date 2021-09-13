using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class BookingVindue : IBookingVindue
    {
        public int Id { get; set; }
        public List<IBooking> BookingListe { get; set; } = new List<IBooking>();
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }
        public int KalenderId { get; set; }

        public void AddBooking(IBooking booking)
        {
            if (booking.PasserMedVindue(this) == false)
            {
                throw new ArgumentOutOfRangeException("Fejl: Booking udenfor tidsrammen");
            }

            foreach (var eksisterendeBooking in BookingListe)
            {
                if (booking.HarOverlap(eksisterendeBooking))
                {
                    throw new ArgumentOutOfRangeException("Fejl: Booking overlapper anden booking");
                }
            }

            BookingListe.Add(booking);
        }
    }
}
