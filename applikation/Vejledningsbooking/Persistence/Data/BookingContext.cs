using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext()
        {
        }
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
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
