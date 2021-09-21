using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Vejledningsbooking.Application;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Domain;
using System.Linq;

namespace Vejledningsbooking.Persistence
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {
        }

        public Kalender LoadKalender(int underviserId, int holdId) { return new Kalender(); }
        public BookingVindue LoadBookingVindue(int id) { return new BookingVindue(); }
        public void CreateBooking(Booking booking) { }
        public Booking LoadBooking(int id) { return new Booking(); }

        //private void OpenConnection()
        //{
        //    if (_conn.State == ConnectionState.Closed)
        //    {
        //        _conn.Open();
        //    }
        //}

        //public Kalender LoadKalender(int underviserId, int holdId)
        //{
        //    Kalender kalender = new Kalender();
        //    kalender.UnderviserId = underviserId;
        //    kalender.HoldId = holdId;

        //    OpenConnection();

        //    string query = "SELECT * FROM BookingVindue WHERE UnderviserId = @UId AND HoldId = @HId";
        //    SqlCommand command = new SqlCommand(query, _conn);
        //    command.Parameters.AddWithValue("@UId", kalender.UnderviserId);
        //    command.Parameters.AddWithValue("@HId", kalender.HoldId);
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read() == true)
        //    {
        //        int nextId = reader.GetInt32(0);
        //        kalender.BookingVinduer.Add(LoadBookingVindue(nextId));
        //    }

        //    _conn.Close();

        //    return kalender;
        //}

        //public BookingVindue LoadBookingVindue(int id)
        //{
        //    BookingVindue bookingVindue = new BookingVindue();
        //    bookingVindue.BookingVindueId = id;

        //    // Load bookingvinduet

        //    string query = "SELECT * FROM BookingVindue WHERE BookingVindueId = @Id";
        //    SqlCommand command = new SqlCommand(query, _conn);
        //    command.Parameters.AddWithValue("@Id", id);
        //    SqlDataReader reader = command.ExecuteReader();
        //    reader.Read();

        //    bookingVindue.StartTidspunkt = reader.GetDateTime(2);
        //    bookingVindue.SlutTidspunkt = reader.GetDateTime(3);

        //    // Load tilhørende bookinger

        //    query = "SELECT * FROM Booking WHERE BookingVindueId = @Id";
        //    command = new SqlCommand(query, _conn);
        //    command.Parameters.AddWithValue("@Id", id);
        //    reader = command.ExecuteReader();

        //    while (reader.Read() == true)
        //    {
        //        int nextId = reader.GetInt32(0);
        //        bookingVindue.Bookinger.Add(LoadBooking(nextId));
        //    }

        //    return bookingVindue;
        //}

        //public void CreateBooking(Booking booking)
        //{
        //    // Opret ny booking i databasen ud fra input parameteren
        //}

        //public Booking LoadBooking(int id)
        //{
        //    Booking booking = new Booking();
        //    booking.BookingVindueId = id;

        //    string query = "SELECT * FROM Booking WHERE BookingId = @Id";
        //    SqlCommand command = new SqlCommand(query, _conn);
        //    command.Parameters.AddWithValue("@Id", id);
        //    SqlDataReader reader = command.ExecuteReader();
        //    reader.Read();

        //    booking.StartTidspunkt = reader.GetDateTime(1);
        //    booking.SlutTidspunkt = reader.GetDateTime(2);

        //    return booking;
        //}

        public void UpdateBooking(BookingCommand bookingData)
        {
            using (var db = new Data.BookingContext())
            {
                var booking = db.Bookinger
                    .Single(b => b.BookingId == bookingData.Id);
                // Single = Finder ét element der matcher conditions
                // Kaster en fejl, hvis der er 0 eller mere end 1 match

                booking.StartTidspunkt = bookingData.StartTidspunkt;
                booking.SlutTidspunkt = bookingData.SlutTidspunkt;
                db.SaveChanges();
            }
        }
    }
}
