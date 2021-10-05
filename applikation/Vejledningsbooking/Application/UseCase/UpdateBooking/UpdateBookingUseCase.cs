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
    public class UpdateBookingUseCase : IUpdateBookingUseCase
    {
        private IBookingRepository _db;

        public UpdateBookingUseCase(IBookingRepository db)
        {
            _db = db;
        }

        public void UpdateBooking(BookingCommand data)
        {
            Booking booking = new Booking()
            {
                Id = data.BookingId,
                StartTidspunkt = data.StartTidspunkt,
                SlutTidspunkt = data.SlutTidspunkt
            };

            _db.UpdateBooking(booking);
        }
    }
}
