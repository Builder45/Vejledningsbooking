using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vejledningsbooking.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        public byte[] RowVersion { get; set; }
        //public int? StuderendeId { get; set; }
        public Studerende Studerende { get; set; }
        //public int? BookingVindueId { get; set; }
        public BookingVindue BookingVindue { get; set; }

        public Booking() { }

        public Booking(DateTime startTidspunkt, DateTime slutTidspunkt)
        {
            StartTidspunkt = startTidspunkt;
            SlutTidspunkt = slutTidspunkt;
        }

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
