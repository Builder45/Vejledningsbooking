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
        [Key, Column(Order = 0)]
        public int? UnderviserId { get; set; }
        public virtual Underviser Underviser { get; set; }

        [Key, Column(Order = 1)]
        public int? HoldId { get; set; }
        public virtual Hold Hold { get; set; }

        public virtual ICollection<BookingVindue> BookingVinduer { get; set; }

    }
}
