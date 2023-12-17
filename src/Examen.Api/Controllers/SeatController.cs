using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [Route("api/seat")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeat _seat;

        public SeatController(ISeat seat)
        {
            _seat = seat;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _seat.GetSeat();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(SeatDTO seat)
        {
            var response = await _seat.PostSeat(seat);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int idSeat, SeatDTO seat)
        {
            var response = await _seat.PutSeat(seat, idSeat);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int idSeat)
        {
            var response = await _seat.DeleteSeat(idSeat);
            return Ok(response);
        }
    }
}
