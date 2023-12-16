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
            if (response == null) { return NotFound(); } else { return Ok(response); };
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoomDTO room)
        {
            var response = await _room.PostRoom(room);
            if (response) { return NotFound(); } else { return Ok(response); };
        }

        [HttpPut("{idRoom:int}")]
        public async Task<ActionResult> Put(int idRoom, [FromBody] RoomDTO room)
        {
            var response = await _room.PutRooom(idRoom, room);
            if (response) { return NotFound(); } else { return Ok(response); };
        }

        [HttpDelete("{idRoom:int}")]
        public async Task<ActionResult> Delete(int IdRoom)
        {
            var response = await _room.DeleteRoom(IdRoom);
            if (response) { return NotFound(); } else { return Ok(response); };
        }
    }
}
