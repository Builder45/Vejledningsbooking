using System;
using System.Collections.Generic;

namespace Vejledningsbooking.Domain
{
    public interface IKalender
    {
        int UnderviserId { get; set; }
        int HoldId { get; set; }
        List<IBookingVindue> BookingVindueListe { get; set; }
    }
}