using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Factory
    {
        public IKalender CreateKalender()
        {
            return new Kalender();
        }

        public IBookingVindue CreateBookingVindue()
        {
            return new BookingVindue();
        }

        public IBooking CreateBooking()
        {
            return new Booking();
        }
    }
}
