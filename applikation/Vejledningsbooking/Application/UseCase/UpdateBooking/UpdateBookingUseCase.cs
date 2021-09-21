using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vejledningsbooking.Application.Commands;

namespace Vejledningsbooking.Application.UseCase
{
    public class UpdateBookingUseCase
    {
        private IDatabaseService _dbService;

        public UpdateBookingUseCase(IDatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        public void Execute(BookingCommand booking)
        {
            _dbService.UpdateBooking(booking);
        }
    }
}
