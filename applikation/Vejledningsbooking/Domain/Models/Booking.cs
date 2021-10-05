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

        public bool HarOverlap(BookingVindue bookingVindue)
        {
            foreach (var booking in bookingVindue.Bookinger)
            {
                if (booking.StartTidspunkt > this.StartTidspunkt &&
                    booking.StartTidspunkt < this.SlutTidspunkt)
                {
                    return true;
                }
                if (booking.SlutTidspunkt > this.StartTidspunkt &&
                    booking.StartTidspunkt < this.SlutTidspunkt)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PasserMedVindue(BookingVindue bookingVindue)
        {
            if (this.StartTidspunkt < bookingVindue.StartTidspunkt ||
                this.SlutTidspunkt > bookingVindue.SlutTidspunkt)
            {
                return false;
            }

            return true;
        }
    }
}
