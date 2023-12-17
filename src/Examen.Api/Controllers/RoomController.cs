using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _room.GetRooms();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoomDTO room)
        {
            var response = await _room.PostRoom(room);
            return Ok(response);
        }

        [HttpPut("{idRoom:int}")]
        public async Task<ActionResult> Put(int idRoom, RoomDTO room)
        {
            var response = await _room.PutRoom(idRoom, room);
            return Ok(response);
        }

        [HttpDelete("{idRoom:int}")]
        public async Task<ActionResult> Delete(int idRoom)
        {
            var response = await _room.DeleteRoom(idRoom);
            return Ok(response);
        }
    }
}
