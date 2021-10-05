using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Hold
    {
        public int Id { get; set; }

        public ICollection<Kalender> Kalendere { get; set; }
    }
}
