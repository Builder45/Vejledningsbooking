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
        void CreateBooking(Booking booking);
        Booking LoadBooking(int id);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }
}
