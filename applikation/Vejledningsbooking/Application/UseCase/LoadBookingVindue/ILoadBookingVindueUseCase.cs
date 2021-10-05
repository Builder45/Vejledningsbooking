using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase.LoadBookingVindue
{
    public interface ILoadBookingVindueUseCase
    {
        BookingVindue LoadBookingVindue(int id);
    }
}