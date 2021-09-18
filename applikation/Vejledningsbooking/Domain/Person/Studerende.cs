using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Studerende
    {
        public int StuderendeId { get; set; }
        public string Navn { get; set; }

        public virtual ICollection<Booking> Bookinger { get; set; }
    }
}
