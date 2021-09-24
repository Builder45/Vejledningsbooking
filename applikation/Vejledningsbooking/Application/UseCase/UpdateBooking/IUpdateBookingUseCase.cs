using Vejledningsbooking.Application.Commands;

namespace Vejledningsbooking.Application.UseCase
{
    public interface IUpdateBookingUseCase
    {
        void UpdateBooking(BookingCommand data);
    }
}