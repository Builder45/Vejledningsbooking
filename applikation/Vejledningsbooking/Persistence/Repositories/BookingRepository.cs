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

        public void CreateBooking(Booking bookingData)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(Booking bookingData)
        {
            throw new NotImplementedException();
        }

        public Booking LoadBooking(int id)
        {
            Booking booking = db.Booking
                    .Single(b => b.BookingId == id);
            return booking;
        }

        public void UpdateBooking(Booking bookingData)
        {
            var booking = db.Booking
                    .Single(b => b.BookingId == bookingData.BookingId);
            // Single = Finder ét element der matcher conditions
            // Kaster en fejl, hvis der er 0 eller mere end 1 match

            
            booking.StartTidspunkt = bookingData.StartTidspunkt;
            booking.SlutTidspunkt = bookingData.SlutTidspunkt;
            db.SaveChanges();
        }
    }
}
