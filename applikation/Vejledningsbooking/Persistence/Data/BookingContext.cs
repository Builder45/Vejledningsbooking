using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Data
{
    public class BookingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConfigurationManager.ConnectionStrings["ExternalBookingDB"].ConnectionString);
        }

        public DbSet<Booking> Bookinger { get; set; }
        public DbSet<BookingVindue> BookingVinduer { get; set; }
        public DbSet<Kalender> Kalendere { get; set; }
        public DbSet<Hold> Hold { get; set; }
        public DbSet<Underviser> Undervisere { get; set; }
        public DbSet<Studerende> Studerende { get; set; }
    }
}
