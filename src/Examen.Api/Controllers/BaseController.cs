using Examen.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Examen.Domain.DTO;

namespace Examen.Api.Controllers
{
    [Route("api/base")]
    [ApiController]
    public class BaseController : Controller
    {
        private readonly IBase _base;

        public BaseController(IBase based)
        {
            _base = based;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _base.GetBases();
            if (response == null) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BaseDTO based)
        {
            var response = await _base.PostBase(based);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpPut("{idBase:int}")]
        public async Task<ActionResult> Put(int idBase, [FromBody] BaseDTO based)
        {
            var response = await _base.PutCBase(idBase, based);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpDelete("{idBase:int}")]
        public async Task<ActionResult> Delete(int idBase)
        {
            var response = await _base.DeleteBase(idBase);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }
    }
}
