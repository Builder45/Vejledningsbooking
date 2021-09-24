using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;
using Vejledningsbooking.Persistence.Data;

namespace Vejledningsbooking.Persistence.Repositories
{
    class BookingVindueRepository : IBookingVindueRepository
    {
        private readonly BookingContext db;
        public BookingVindueRepository(BookingContext context)
        {
            db = context;
        }

        public void CreateBookingVindue(BookingVindueCommand data)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookingVindue(BookingVindueCommand data)
        {
            throw new NotImplementedException();
        }

        public BookingVindue LoadBookingVindue(BookingVindueCommand data)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookingVindue(BookingVindueCommand data)
        {
            throw new NotImplementedException();
        }
    }
}
