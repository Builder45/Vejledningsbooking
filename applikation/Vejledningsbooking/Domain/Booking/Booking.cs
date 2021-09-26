using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vejledningsbooking.Domain
{
    public class Booking
    {
        [Column(Order = 0)]
        public int BookingId { get; set; }
        [Column(Order = 1)]
        public DateTime StartTidspunkt { get; set; }
        [Column(Order = 2)]
        public DateTime SlutTidspunkt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public int? StuderendeId { get; set; }
        public virtual Studerende Studerende { get; set; }
        public int? BookingVindueId { get; set; }
        public virtual BookingVindue BookingVindue { get; set; }

        public bool HarOverlap(Booking booking)
        {
            if (booking.StartTidspunkt.Ticks > this.StartTidspunkt.Ticks &&
                    booking.StartTidspunkt.Ticks < this.SlutTidspunkt.Ticks)
            {
                return true;
            }

            if (booking.SlutTidspunkt.Ticks <= this.StartTidspunkt.Ticks ||
                booking.SlutTidspunkt.Ticks >= this.SlutTidspunkt.Ticks) return false;
            return true;

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
