using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public interface ILoadBookingUseCase
    {
        Booking LoadBooking(int id);
    }
}