using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejledningsbooking.API.DTO;
using Vejledningsbooking.Application.Commands;
using Vejledningsbooking.Application.UseCase;
using Vejledningsbooking.Application.UseCase.CreateBooking;
using Vejledningsbooking.Application.UseCase.LoadBookingVindue;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vejledningsbooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ICreateBookingUseCase _createBookingUseCase;
        private readonly ILoadBookingUseCase _loadBookingUseCase;
        private readonly IUpdateBookingUseCase _updateBookingUseCase;
        private readonly ILoadBookingVindueUseCase _loadBookingVindueUseCase;

        public BookingController(ICreateBookingUseCase createBookingUseCase, ILoadBookingUseCase loadBookingUseCase, IUpdateBookingUseCase updateBookingUseCase, ILoadBookingVindueUseCase loadBookingVindueUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _loadBookingUseCase = loadBookingUseCase;
            _updateBookingUseCase = updateBookingUseCase;
            _loadBookingVindueUseCase = loadBookingVindueUseCase;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IEnumerable<BookingDTO> Get(int bookingVindueId)
        {
            var model = _loadBookingUseCase.LoadBookings(new BookingCommand { BookingVindueId = bookingVindueId });
            var dto = new List<BookingDTO>();
            model.ForEach(b => dto.Add(new BookingDTO 
                { Id = b.Id, StartTidspunkt = b.StartTidspunkt, SlutTidspunkt = b.SlutTidspunkt }));
            return dto;
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] BookingDTO dto)
        {
            _createBookingUseCase.CreateBooking(new BookingCommand 
                { BookingVindueId = dto.BookingVindueId, StartTidspunkt = dto.StartTidspunkt, SlutTidspunkt = dto.SlutTidspunkt });
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
