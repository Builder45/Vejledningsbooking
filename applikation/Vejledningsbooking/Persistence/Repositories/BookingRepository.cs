using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;
using Vejledningsbooking.Persistence.Data;

namespace Vejledningsbooking.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext db;
        public BookingRepository(BookingContext context)
        {
            db = context;
        }

        public void CreateBooking(BookingCommand data)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(BookingCommand data)
        {
            throw new NotImplementedException();
        }

        public Booking LoadBooking(BookingCommand data)
        {
            throw new NotImplementedException();
        }

        public void UpdateBooking(BookingCommand data)
        {
            var booking = db.Booking
                    .Single(b => b.BookingId == data.Id);
            // Single = Finder ét element der matcher conditions
            // Kaster en fejl, hvis der er 0 eller mere end 1 match

            booking.StartTidspunkt = data.StartTidspunkt;
            booking.SlutTidspunkt = data.SlutTidspunkt;
            db.SaveChanges();
        }
    }
}
