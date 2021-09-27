using Microsoft.EntityFrameworkCore;
using System;
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
            try
            {
                var booking = db.Booking
                    .Single(b => b.BookingId == bookingData.BookingId);

                booking.StartTidspunkt = bookingData.StartTidspunkt;
                booking.SlutTidspunkt = bookingData.SlutTidspunkt;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Concurrency fejl!");
            }
        }
    }
}
