using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [Route("api/billboard")]
    [ApiController]
    public class BillboardController : Controller
    {
        private readonly IBillboard _billboard;

        public BillboardController(IBillboard billboard)
        {
            _billboard = billboard;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BillboardDTO billboard)
        {
            var response = await _billboard.PostBillboard(billboard);
            if(response) { return Ok(response); } else { return BadRequest(response) ; }
        }

        [HttpPut("{idBillboard:int}")]
        public async Task<ActionResult> Put(int idBillboard, [FromBody] BillboardDTO billboard)
        {
            var response = await _billboard.PutBillboard(idBillboard, billboard);
            if (response) { return Ok(response); } else { return BadRequest(response); }
        }

        [HttpDelete("{idBillboard:int}")]
        public async Task<ActionResult> Delete(int idBillboard)
        {
            var response = await _billboard.DeleteBillboard(idBillboard);
            if (response) { return Ok(response); } else { return BadRequest(response); }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _billboard.GetBillboard();
            if (response != null) { return Ok(response); } else { return BadRequest(response); }
        }
    }
}
