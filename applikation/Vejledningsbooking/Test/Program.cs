using System;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.UseCase;
using Vejledningsbooking.Persistence;

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
                DatabaseService db = new DatabaseService();
                UpdateBookingUseCase updateBooking = new UpdateBookingUseCase(db);

                BookingCommand booking = new BookingCommand();
                booking.Id = 4;
                booking.StartTidspunkt = new DateTime(2021, 11, 11, 13, 15, 00);
                booking.SlutTidspunkt = new DateTime(2021, 11, 11, 14, 00, 00);
                updateBooking.Execute(booking);
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
