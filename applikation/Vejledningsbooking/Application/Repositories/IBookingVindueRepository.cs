using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.Repositories
{
    public interface IBookingVindueRepository
    {
        void CreateBookingVindue(BookingVindueCommand data);
        BookingVindue LoadBookingVindue(BookingVindueCommand data);
        void UpdateBookingVindue(BookingVindueCommand data);
        void DeleteBookingVindue(BookingVindueCommand data);
    }
}
