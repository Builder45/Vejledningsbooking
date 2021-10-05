using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingVindue> BookingVindue { get; set; }
        public DbSet<Kalender> Kalender { get; set; }
        public DbSet<Hold> Hold { get; set; }
        public DbSet<Underviser> Underviser { get; set; }
        public DbSet<Studerende> Studerende { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
 