using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Booking : IBooking
    {
        public int Id { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }
        public int BookingVindueId { get; set; }

        public bool HarOverlap(IBooking booking)
        {
            if (booking.StartTidspunkt.Ticks > this.StartTidspunkt.Ticks &&
                    booking.StartTidspunkt.Ticks < this.SlutTidspunkt.Ticks)
            {
                return true;
            }

            if (booking.SlutTidspunkt.Ticks > this.StartTidspunkt.Ticks &&
                booking.SlutTidspunkt.Ticks < this.SlutTidspunkt.Ticks)
            {
                return true;
            }

            return false;
        }

        public bool PasserMedVindue(IBookingVindue bookingVindue)
        {
            if (this.StartTidspunkt.Ticks < bookingVindue.StartTidspunkt.Ticks ||
                this.SlutTidspunkt.Ticks > bookingVindue.SlutTidspunkt.Ticks)
            {
                return false;
            }

            return true;
        }
    }
}
