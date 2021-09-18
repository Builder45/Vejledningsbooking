using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Vejledningsbooking.Application;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence
{
    public class DatabaseService : IDatabaseService
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        public DatabaseService()
        {
        }

        private void OpenConnection()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public Kalender LoadKalender(int underviserId, int holdId)
        {
            IKalender kalender = _factory.CreateKalender();
            kalender.UnderviserId = underviserId;
            kalender.HoldId = holdId;

            OpenConnection();

            string query = "SELECT * FROM BookingVindue WHERE UnderviserId = @UId AND HoldId = @HId";
            SqlCommand command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@UId", kalender.UnderviserId);
            command.Parameters.AddWithValue("@HId", kalender.HoldId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                int nextId = reader.GetInt32(0);
                kalender.BookingVindueListe.Add(LoadBookingVindue(nextId));
            }

            _conn.Close();

            return kalender;
        }

        public BookingVindue LoadBookingVindue(int id)
        {
            IBookingVindue bookingVindue = _factory.CreateBookingVindue();
            bookingVindue.Id = id;

            // Load bookingvinduet

            string query = "SELECT * FROM BookingVindue WHERE BookingVindueId = @Id";
            SqlCommand command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            bookingVindue.StartTidspunkt = reader.GetDateTime(2);
            bookingVindue.SlutTidspunkt = reader.GetDateTime(3);

            // Load tilhørende bookinger

            query = "SELECT * FROM Booking WHERE BookingVindueId = @Id";
            command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@Id", id);
            reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                int nextId = reader.GetInt32(0);
                bookingVindue.BookingListe.Add(LoadBooking(nextId));
            }

            return bookingVindue;
        }

        public void CreateBooking(Booking booking)
        {
            // Opret ny booking i databasen ud fra input parameteren
        }

        public Booking LoadBooking(int id)
        {
            IBooking booking = _factory.CreateBooking();
            booking.Id = id;

            string query = "SELECT * FROM Booking WHERE BookingId = @Id";
            SqlCommand command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            booking.StartTidspunkt = reader.GetDateTime(1);
            booking.SlutTidspunkt = reader.GetDateTime(2);

            return booking;
        }
    }
}
