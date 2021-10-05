using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Repositories
{
    class KalenderRepository : IKalenderRepository
    {
        private readonly BookingContext db;
        public KalenderRepository(BookingContext context)
        {
            db = context;
        }

        public void CreateKalender(KalenderCommand data)
        {
            throw new NotImplementedException();
        }

        public void DeleteKalender(KalenderCommand data)
        {
            throw new NotImplementedException();
        }

        public Kalender LoadKalender(KalenderCommand data)
        {
            //Kalender kalender = db.Kalender
            //        .Single(k => k.UnderviserId == data.UnderviserId &&
            //                     k.HoldId == data.HoldId);

            //List<BookingVindue> bookingVinduer = db.BookingVindue
            //    .Where(b => b.UnderviserId == data.UnderviserId &&
            //                b.HoldId == data.HoldId)
            //    .ToList();

            //foreach (var bookingVindue in bookingVinduer)
            //{
            //    List<Booking> bookinger = db.Booking
            //        .Where(b => b.BookingVindueId == bookingVindue.Id)
            //        .ToList();
            //    bookingVindue.Bookinger = bookinger;
            //}

            //kalender.BookingVinduer = bookingVinduer;
            //return kalender;
            return new Kalender();
        }

        public void UpdateKalender(KalenderCommand data)
        {
            throw new NotImplementedException();
        }
    }
}
