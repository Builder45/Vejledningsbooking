using System;

namespace Vejledningsbooking.Domain
{
    public interface IBooking
    {
        int Id { get; set; }
        DateTime SlutTidspunkt { get; set; }
        DateTime StartTidspunkt { get; set; }
        int BookingVindueId { get; set; }

        bool HarOverlap(IBooking booking);
        bool PasserMedVindue(IBookingVindue bookingVindue);
    }
}