using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Test
{
    [TestClass]
    public class AddBookingTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Fejl: Booking udenfor tidsrammen")]
        public void BookingTimeslotNotInsideBookingVindueTimeslot()
        {
            var start = new DateTime(2021, 9, 15, 14, 00, 00);
            var slut = new DateTime(2021, 9, 15, 16, 00, 00);
            var bookingVindue = new BookingVindue(1, start, slut);

            start = new DateTime(2021, 9, 15, 13, 45, 00);
            slut = new DateTime(2021, 9, 15, 14, 15, 00);
            var booking = new Booking(1, start, slut);

            bookingVindue.AddBooking(booking);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Fejl: Booking overlapper anden booking")]
        public void BookingTimeslotOverlappingOtherBookingTimeslot()
        {
            var start = new DateTime(2021, 9, 15, 14, 00, 00);
            var slut = new DateTime(2021, 9, 15, 16, 00, 00);
            var bookingVindue = new BookingVindue(1, start, slut);

            start = new DateTime(2021, 9, 15, 14, 00, 00);
            slut = new DateTime(2021, 9, 15, 14, 30, 00);
            var booking1 = new Booking(1, start, slut);

            bookingVindue.AddBooking(booking1);

            start = new DateTime(2021, 9, 15, 14, 25, 00);
            slut = new DateTime(2021, 9, 15, 14, 55, 00);
            var booking2 = new Booking(1, start, slut);

            bookingVindue.AddBooking(booking2);
        }

        [TestMethod]
        public void BookingTimeslotWithinBookingVindueTimeslot()
        {
            var start = new DateTime(2021, 9, 15, 14, 00, 00);
            var slut = new DateTime(2021, 9, 15, 16, 00, 00);
            var bookingVindue = new BookingVindue(1, start, slut);

            start = new DateTime(2021, 9, 15, 14, 00, 00);
            slut = new DateTime(2021, 9, 15, 14, 30, 00);
            var booking = new Booking(1, start, slut);

            bookingVindue.AddBooking(booking);

            int result = bookingVindue.BookingListe.Count;

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void BookingTimeslotNotOverlappingOtherBookingTimeslot()
        {
            var start = new DateTime(2021, 9, 15, 14, 00, 00);
            var slut = new DateTime(2021, 9, 15, 16, 00, 00);
            var bookingVindue = new BookingVindue(1, start, slut);

            start = new DateTime(2021, 9, 15, 14, 00, 00);
            slut = new DateTime(2021, 9, 15, 14, 30, 00);
            var booking1 = new Booking(1, start, slut);

            bookingVindue.AddBooking(booking1);

            start = new DateTime(2021, 9, 15, 14, 30, 00);
            slut = new DateTime(2021, 9, 15, 15, 00, 00);
            var booking2 = new Booking(1, start, slut);

            bookingVindue.AddBooking(booking2);

            int result = bookingVindue.BookingListe.Count;

            Assert.AreEqual(result, 2);
        }
    }
}
