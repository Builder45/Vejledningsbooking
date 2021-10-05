using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase.CreateBooking
{
    public class CreateBookingUseCase : ICreateBookingUseCase
    {
        private IBookingRepository _db;
        private IBookingVindueRepository _bookingVindueDb;

        public CreateBookingUseCase(IBookingRepository db, IBookingVindueRepository bookingVindueDb)
        {
            _db = db;
            _bookingVindueDb = bookingVindueDb;
        }

        public void CreateBooking(BookingCommand data)
        {
            var bookingVindue = _bookingVindueDb.LoadBookingVindue(data.BookingVindueId);
            var booking = new Booking(data.StartTidspunkt, data.SlutTidspunkt);
            booking.BookingVindue = bookingVindue;

            if (!booking.PasserMedVindue(bookingVindue)) throw new Exception();
            if (booking.HarOverlap(bookingVindue)) throw new Exception();

            _db.CreateBooking(booking);
        }
    }
}
