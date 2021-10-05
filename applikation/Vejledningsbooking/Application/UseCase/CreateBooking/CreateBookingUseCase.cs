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

        public CreateBookingUseCase(IBookingRepository db)
        {
            _db = db;
        }

        public void CreateBooking(BookingCommand data)
        {
            Booking booking = new Booking()
            {
                StartTidspunkt = data.StartTidspunkt,
                SlutTidspunkt = data.SlutTidspunkt
            };

            _db.CreateBooking(booking);
        }
    }
}
