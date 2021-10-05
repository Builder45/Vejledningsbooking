using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;
using Vejledningsbooking.Persistence;

namespace Vejledningsbooking.Persistence.Repositories
{
    class BookingVindueRepository : IBookingVindueRepository
    {
        private readonly BookingContext db;
        public BookingVindueRepository(BookingContext context)
        {
            db = context;
        }

        public void CreateBookingVindue(BookingVindue data)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookingVindue(BookingVindue data)
        {
            throw new NotImplementedException();
        }

        public BookingVindue LoadBookingVindue(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookingVindue(BookingVindue data)
        {
            throw new NotImplementedException();
        }
    }
}
