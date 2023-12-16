using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBooking _booking;

        public BookingController(IBooking booking)
        {
            _booking = booking;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _booking.GetBookings();
            if (response == null) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookingDTO booking)
        {
            var response = await _booking.PostBooking(booking);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpPut("{idBook:int}")]
        public async Task<ActionResult> Put(int idBook, [FromBody] BookingDTO booking)
        {
            var response = await _booking.PutBooking(idBook, booking);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpDelete("{idBook:int}")]
        public async Task<ActionResult> Delete(int idBook)
        {
            var response = await _booking.DeleteBooking(idBook);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }
    }
}
