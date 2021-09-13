using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Underviser : IPerson
    {
        public int Id { get; set; }
        public string Navn { get; set; }
    }
}
