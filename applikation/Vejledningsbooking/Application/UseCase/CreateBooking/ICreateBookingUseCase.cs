using Vejledningsbooking.Application.Commands;

namespace Vejledningsbooking.Application.UseCase.CreateBooking
{
    public interface ICreateBookingUseCase
    {
        void CreateBooking(BookingCommand data);
    }
}