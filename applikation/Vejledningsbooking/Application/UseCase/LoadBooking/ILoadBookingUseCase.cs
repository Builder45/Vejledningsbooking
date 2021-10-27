using System.Collections.Generic;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public interface ILoadBookingUseCase
    {
        Booking LoadBooking(BookingCommand command);
        List<Booking> LoadBookings(BookingCommand command);
    }
}