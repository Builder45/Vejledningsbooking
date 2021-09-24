using System;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.UseCase;
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
                BookingContext context = new BookingContext();
                BookingRepository db = new BookingRepository(context);
                UpdateBookingUseCase updateBooking = new UpdateBookingUseCase(db);

                BookingCommand bookingData = new BookingCommand();
                bookingData.Id = 4;
                bookingData.StartTidspunkt = new DateTime(2021, 11, 11, 13, 15, 00);
                bookingData.SlutTidspunkt = new DateTime(2021, 11, 11, 14, 00, 00);
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
