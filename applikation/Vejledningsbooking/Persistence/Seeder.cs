using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence
{
    public class Seeder
    {
        public void Seed()
        {
            using (var db = new Data.BookingContext())
            {
                db.Underviser.AddRange(
                    new Underviser() { UnderviserId = 1, Navn = "Karsten" },
                    new Underviser() { UnderviserId = 2, Navn = "Grete" },
                    new Underviser() { UnderviserId = 3, Navn = "Kirsten" });

                db.Studerende.AddRange(
                    new Studerende() { StuderendeId = 1, Navn = "Nils" },
                    new Studerende() { StuderendeId = 2, Navn = "Magnus" },
                    new Studerende() { StuderendeId = 3, Navn = "Sune" });

                db.Hold.AddRange(
                    new Hold(){ HoldId = 1 }, 
                    new Hold(){ HoldId = 2 },
                    new Hold(){ HoldId = 3 });

                db.Kalender.AddRange(
                    new Kalender() { UnderviserId = 1, HoldId = 1 },
                    new Kalender() { UnderviserId = 1, HoldId = 2 },
                    new Kalender() { UnderviserId = 2, HoldId = 1 });

                db.BookingVindue.AddRange(
                    new BookingVindue() { BookingVindueId = 1, StartTidspunkt = new DateTime(0),
                                          UnderviserId = 1, SlutTidspunkt = new DateTime(0),
                                          KalenderUnderviserId = 1, KalenderHoldId = 1},
                    new BookingVindue() { BookingVindueId = 1, StartTidspunkt = new DateTime(0),
                                          UnderviserId = 1, SlutTidspunkt = new DateTime(0),
                                          KalenderUnderviserId = 1, KalenderHoldId = 1},
                    new BookingVindue() { BookingVindueId = 1, StartTidspunkt = new DateTime(0),
                                          UnderviserId = 1, SlutTidspunkt = new DateTime(0),
                                          KalenderUnderviserId = 1, KalenderHoldId = 1});

                //db.Booking.AddRange(
                //    new Hold() { HoldId = 1 },
                //    new Hold() { HoldId = 1 },
                //    new Hold() { HoldId = 1 });

                db.SaveChanges();
            }
        }
    }
}
