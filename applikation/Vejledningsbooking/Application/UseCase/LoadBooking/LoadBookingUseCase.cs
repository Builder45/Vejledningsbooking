using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase
{
    public class LoadBookingUseCase : ILoadBookingUseCase
    {
        private IBookingRepository _db;

        public LoadBookingUseCase(IBookingRepository db)
        {
            _db = db;
        }

        public Booking LoadBooking(int id)
        {
            return _db.LoadBooking(id);
        }
    }
}
