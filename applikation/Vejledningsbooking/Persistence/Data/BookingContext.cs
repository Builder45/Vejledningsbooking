using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Reflection;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Data
{
    public class BookingContext : DbContext
    {
        //public string DbPath { get; private set; }
        public BookingContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}booking.db";
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingVindue> BookingVindue { get; set; }
        public DbSet<Kalender> Kalender { get; set; }
        public DbSet<Hold> Hold { get; set; }
        public DbSet<Underviser> Underviser { get; set; }
        public DbSet<Studerende> Studerende { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=mssql-50861-0.cloudclusters.net,16277; Database=BookingTest; User ID=SuperUser; Password=SuperSuper1; TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kalender>()
                .HasKey(c => new { c.UnderviserId, c.HoldId });
        }
    }
}
 