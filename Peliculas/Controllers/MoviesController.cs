using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Business;
using Peliculas.Dtos;

namespace Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieBl _movieBl;

        public MoviesController(MovieBl movieBl)
        {
            this._movieBl = movieBl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieBl.GetMoviesAsync();

            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int movieId)
        {
            var movie = await _movieBl.GetMovieAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(MovieDtoIn movie)
        {
            int id;

            id = await _movieBl.AddAsync(movie);

            //Objeto anonimo
            return Created("", new { Id = id });
        }

        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int movieId, [FromBody] MovieDtoIn movie)
        {
            var result = await _movieBl.UpdateAsync(movieId, movie);

            if (!result)
            {
                // Si el resultado es 'false', mandamos un 404.
                return NotFound(new { Message = $"Movie with ID {movieId} not found." });
            }

            return Accepted(new { Message = "Movie update" });
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int movieId)
        {
            var result = await _movieBl.DeleteAsync(movieId);

            if (!result)
            {
                return NotFound(new { Message = $"Movie with ID {movieId} not found." });
            }
            return NoContent();
        }
    }
}
