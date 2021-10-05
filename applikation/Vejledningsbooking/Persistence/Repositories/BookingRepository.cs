using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;
using Vejledningsbooking.Persistence;

namespace Vejledningsbooking.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext db;
        public BookingRepository(BookingContext context)
        {
            db = context;
        }

        public void CreateBooking(Booking booking)
        {
            db.Booking.Add(booking);
            db.SaveChanges();
        }

        public void DeleteBooking(Booking data)
        {
            throw new NotImplementedException();
        }

        public Booking LoadBooking(int id)
        {
            Booking booking = db.Booking
                    .Single(b => b.Id == id);
            return booking;
        }

        public void UpdateBooking(Booking data)
        {
            try
            {
                var booking = db.Booking
                    .Single(b => b.Id == data.Id);

                booking.StartTidspunkt = data.StartTidspunkt;
                booking.SlutTidspunkt = data.SlutTidspunkt;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Concurrency fejl!");
            }
        }
    }
}
