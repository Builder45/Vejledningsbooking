using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.Repositories
{
    public interface IBookingRepository
    {
        void CreateBooking(BookingCommand data);
        Booking LoadBooking(BookingCommand data);
        void UpdateBooking(BookingCommand data);
        void DeleteBooking(BookingCommand data);
    }
}
