using System;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.UseCase.OpretBooking;
using Vejledningsbooking.Persistence;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter to proceed..");
            Console.ReadLine();
            try
            {
                DatabaseService db = new DatabaseService();
                UpdateBookingUseCase updateBooking = new UpdateBookingUseCase(db);

                BookingCommand booking = new BookingCommand();
                booking.Id = 1;
                booking.StartTidspunkt = new DateTime(2021,10,10,15,00,00);
                booking.SlutTidspunkt = new DateTime(2021, 10, 10, 16, 00, 00);
                updateBooking.Execute(booking);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
