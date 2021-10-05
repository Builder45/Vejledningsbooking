using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejledningsbooking.Application.UseCase;
using Vejledningsbooking.Application.UseCase.CreateBooking;

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

        public BookingController(ICreateBookingUseCase createBookingUseCase, ILoadBookingUseCase loadBookingUseCase, IUpdateBookingUseCase updateBookingUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _loadBookingUseCase = loadBookingUseCase;
            _updateBookingUseCase = updateBookingUseCase;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
