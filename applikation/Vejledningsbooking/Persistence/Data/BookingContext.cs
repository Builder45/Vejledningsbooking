using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Reflection;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Data
{
    public class BookingContext : DbContext
    {
        public string DbPath { get; private set; }
        public BookingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}booking.db";
        }
        //public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        //{
        //}

        public DbSet<Booking> Bookinger { get; set; }
        public DbSet<BookingVindue> BookingVinduer { get; set; }
        public DbSet<Kalender> Kalendere { get; set; }
        public DbSet<Hold> Hold { get; set; }
        public DbSet<Underviser> Undervisere { get; set; }
        public DbSet<Studerende> Studerende { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kalender>()
                .HasKey(c => new { c.UnderviserId, c.HoldId });
        }
    }
}
 