using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Data
{
    class BookingContext : DbContext
    {
        public BookingContext(): base()
        {

        }

        public DbSet<Booking> Bookinger { get; set; }
        public DbSet<BookingVindue> BookingVinduer { get; set; }
        public DbSet<Kalender> Kalendere { get; set; }
        public DbSet<Hold> Hold { get; set; }
        public DbSet<Underviser> Undervisere { get; set; }
        public DbSet<Studerende> Studerende { get; set; }
    }
}
