using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vejledningsbooking.API.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int BookingVindueId { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }
    }
}
