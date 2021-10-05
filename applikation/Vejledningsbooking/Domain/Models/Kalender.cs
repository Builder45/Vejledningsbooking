using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Kalender
    {
        public int Id { get; set; }
        //public int UnderviserId { get; set; }
        public Underviser Underviser { get; set; }
        //public int HoldId { get; set; }
        public Hold Hold { get; set; }

        public ICollection<BookingVindue> BookingVinduer { get; set; }

    }
}
