using System;
using System.Collections.Generic;

namespace Vejledningsbooking.Domain
{
    public interface IBookingVindue
    {
        int Id { get; set; }
        DateTime SlutTidspunkt { get; set; }
        DateTime StartTidspunkt { get; set; }
        List<IBooking> BookingListe { get; set; }
        int KalenderId { get; set; }


        void AddBooking(IBooking booking);
    }
}