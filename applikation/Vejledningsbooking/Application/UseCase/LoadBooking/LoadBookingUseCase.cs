using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public class LoadBookingUseCase : ILoadBookingUseCase
    {
        private IBookingRepository _db;

        public LoadBookingUseCase(IBookingRepository db)
        {
            _db = db;
        }

        public Booking LoadBooking(BookingCommand command)
        {
            return _db.LoadBooking(command.BookingId);
        }

        public List<Booking> LoadBookings(BookingCommand command)
        {
            return _db.LoadBookings(command.BookingVindueId);
        }
    }
}
