using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Repositories;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Application.UseCase.LoadBookingVindue
{
    public class LoadBookingVindueUseCase : ILoadBookingVindueUseCase
    {
        private IBookingVindueRepository _db;

        public LoadBookingVindueUseCase(IBookingVindueRepository db)
        {
            _db = db;
        }

        public BookingVindue LoadBookingVindue(int id)
        {
            return _db.LoadBookingVindue(id);
        }
    }
}
