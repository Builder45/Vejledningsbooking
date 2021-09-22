﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vejledningsbooking.Domain
{
    public class Underviser
    {
        public int UnderviserId { get; set; }
        public string Navn { get; set; }

        public virtual ICollection<Kalender> Kalendere { get; set; }
    }
}
