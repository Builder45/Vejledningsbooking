using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public interface IDatabaseService
    {
        Kalender LoadKalender(int underviserId, int holdId);

        BookingVindue LoadBookingVindue(int id);

        void CreateBooking(Booking booking);

        Booking LoadBooking(int id);
    }
}
