using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application
{
    public interface IDatabaseService
    {
        IKalender LoadKalender(int underviserId, int holdId);

        IBookingVindue LoadBookingVindue(int id);

        void CreateBooking(IBooking booking);

        IBooking LoadBooking(int id);
    }
}
