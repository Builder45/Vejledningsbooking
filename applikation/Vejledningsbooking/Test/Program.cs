using System;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.UseCase;
using Vejledningsbooking.Domain;
using Vejledningsbooking.Persistence;
using Vejledningsbooking.Persistence.Data;
using Vejledningsbooking.Persistence.Repositories;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter to proceed..");
            Console.ReadLine();
            testUpdateBooking();
            Console.ReadLine();
        }

        static void testUpdateBooking()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Indtast et BookingId du vil ændre:");
                int id = Convert.ToInt32(Console.ReadLine());

                BookingContext context = new BookingContext();
                BookingRepository db = new BookingRepository(context);

                LoadBookingUseCase loadBooking = new LoadBookingUseCase(db);
                Booking oldBooking = loadBooking.LoadBooking(id);

                Console.WriteLine("Fandt følgende booking:");
                Console.WriteLine(oldBooking.BookingId);
                Console.WriteLine(oldBooking.StartTidspunkt);
                Console.WriteLine(oldBooking.SlutTidspunkt);
                Console.WriteLine();

                Console.WriteLine("Tryk enter for at opdatere den");

                UpdateBookingUseCase updateBooking = new UpdateBookingUseCase(db);

                BookingCommand bookingData = new BookingCommand();
                bookingData.BookingId = id;
                bookingData.StartTidspunkt = new DateTime(2021, 11, 11, 14, 00, 00);
                bookingData.SlutTidspunkt = new DateTime(2021, 11, 11, 15, 00, 00);
                bookingData.RowVersion = oldBooking.RowVersion;
                updateBooking.UpdateBooking(bookingData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(e.Message);
            }
        }

        static void seedDb()
        {
            try
            {
                Seeder seeder = new Seeder();
                seeder.FullSeed();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
