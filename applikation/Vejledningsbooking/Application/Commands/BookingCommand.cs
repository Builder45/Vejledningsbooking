using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Application.Commands
{
    public class BookingCommand
    {
        public int BookingId { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        public byte[] RowVersion { get; set; }
        public int BookingVindueId { get; set; }
    }
}
