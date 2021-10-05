using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.Repositories
{
    public interface IBookingVindueRepository
    {
        void CreateBookingVindue(BookingVindue data);
        BookingVindue LoadBookingVindue(int id);
        void UpdateBookingVindue(BookingVindue data);
        void DeleteBookingVindue(BookingVindue data);
    }
}
