using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.Repositories;

namespace Vejledningsbooking.Application.UseCase
{
    public class UpdateBookingUseCase : IUpdateBookingUseCase
    {
        private IBookingRepository _db;

        public UpdateBookingUseCase(IBookingRepository db)
        {
            _db = db;
        }

        public void UpdateBooking(BookingCommand data)
        {
            _db.UpdateBooking(data);
        }
    }
}
