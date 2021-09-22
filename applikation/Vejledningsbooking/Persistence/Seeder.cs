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
                db.Underviser.Add(new Underviser() { Navn = "Karsten" });
                db.SaveChanges();
            }
        }
        public void FullSeed()
        {
            using (var db = new Data.BookingContext())
            {
                IList<Underviser> undervisere = new List<Underviser>() {
                    new Underviser() { Navn = "Karsten" },
                    new Underviser() { Navn = "Grete" },
                    new Underviser() { Navn = "Kirsten" }
                };

                IList<Studerende> studerende = new List<Studerende>() {
                    new Studerende() { Navn = "Nils" },
                    new Studerende() { Navn = "Magnus" },
                    new Studerende() { Navn = "Sune" }
                };

                IList<Hold> hold = new List<Hold>() {
                    new Hold(),
                    new Hold(),
                    new Hold()
                };

                IList<Kalender> kalendere = new List<Kalender>() {
                    new Kalender() { UnderviserId = 5, HoldId = 5 },
                    new Kalender() { UnderviserId = 5, HoldId = 6 },
                    new Kalender() { UnderviserId = 6, HoldId = 5 }
                };

                IList<BookingVindue> bookingvinduer = new List<BookingVindue>() {
                    new BookingVindue()
                    {
                        StartTidspunkt = new DateTime(2021, 11, 11, 12, 0, 0),
                        SlutTidspunkt = new DateTime(2021, 11, 11, 14, 0, 0),
                        UnderviserId = 5,
                        HoldId = 5
                    },
                    new BookingVindue()
                    {
                        StartTidspunkt = new DateTime(2021, 11, 11, 16, 0, 0),
                        SlutTidspunkt = new DateTime(2021, 11, 11, 19, 0, 0),
                        UnderviserId = 5,
                        HoldId = 6
                    },
                    new BookingVindue()
                    {
                        StartTidspunkt = new DateTime(2021, 11, 11, 12, 0, 0),
                        SlutTidspunkt = new DateTime(2021, 11, 11, 16, 0, 0),
                        UnderviserId = 6,
                        HoldId = 5
                    }
                };

                IList<Booking> bookinger = new List<Booking>() {
                    new Booking()
                    {
                        StartTidspunkt = new DateTime(2021, 11, 11, 12, 0, 0),
                        SlutTidspunkt = new DateTime(2021, 11, 11, 12, 30, 0),
                        StuderendeId = 5,
                        BookingVindueId = 2
                    },
                    new Booking()
                    {
                        StartTidspunkt = new DateTime(2021, 11, 11, 17, 0, 0),
                        SlutTidspunkt = new DateTime(2021, 11, 11, 17, 20, 0),
                        StuderendeId = 6,
                        BookingVindueId = 3
                    },
                    new Booking()
                    {
                        StartTidspunkt = new DateTime(2021, 11, 11, 13, 0, 0),
                        SlutTidspunkt = new DateTime(2021, 11, 11, 14, 0, 0),
                        StuderendeId = 7,
                        BookingVindueId = 4
                    }
                };

                Console.WriteLine("Tilføjer undervisere..");
                Console.ReadLine();
                db.Underviser.AddRange(undervisere);
                db.SaveChanges();

                Console.WriteLine("Tilføjer studerende..");
                Console.ReadLine();
                db.Studerende.AddRange(studerende);
                db.SaveChanges();

                Console.WriteLine("Tilføjer hold..");
                Console.ReadLine();
                db.Hold.AddRange(hold);
                db.SaveChanges();

                Console.WriteLine("Tilføjer kalendere..");
                Console.ReadLine();
                db.Kalender.AddRange(kalendere);
                db.SaveChanges();

                Console.WriteLine("Tilføjer bookingvinduer..");
                Console.ReadLine();
                db.BookingVindue.AddRange(bookingvinduer);
                db.SaveChanges();

                Console.WriteLine("Tilføjer bookinger..");
                Console.ReadLine();
                db.Booking.AddRange(bookinger);
                db.SaveChanges();
            }
        }
    }
}
