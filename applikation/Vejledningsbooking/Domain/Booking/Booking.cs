using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        public int? BookingVindueId { get; set; }
        public virtual BookingVindue BookingVindue { get; set; }

        public bool HarOverlap(Booking booking)
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

        public bool PasserMedVindue(BookingVindue bookingVindue)
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
