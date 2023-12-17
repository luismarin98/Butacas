using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovie _movie;

        public MoviesController(IMovie movie)
        {
            _movie = movie;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _movie.GetMovies();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MovieDTO movie)
        {
            var response = await _movie.PostMovie(movie);
            if(response) {  return Ok(response); } else {  return BadRequest(); }
        }

        [HttpPut("{idMovie:int}")]
        public async Task<ActionResult> Put(int idMovie, [FromBody]  MovieDTO movie)
        {
            var response = await _movie.PutMovie(idMovie, movie);
            if (response) { return Ok(response); } else { return BadRequest(); }
        }

        [HttpDelete("{idMovie:int}")]
        public async Task<ActionResult> Delete(int idMovie)
        {
            var response = await _movie.DeleteMovie(idMovie);
            if (response) { return Ok(response); } else { return BadRequest(); }
        }
    }
}
