using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Kalender : IKalender
    {
        public int UnderviserId { get; set; }
        public int HoldId { get; set; }
        public List<IBookingVindue> BookingVindueListe { get; set; }
    }
}
