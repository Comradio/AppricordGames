using AprikordGames.Interfaces;
using AprikordGames.Models;
using AprikordGames.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AprikordGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<GameGenre> GetAllGenres() => _service.GetAllGenres();

        [HttpGet("{genreId}")]
        public ActionResult<GameGenre> Get(int genreId)
        {
            var genre = _service.GetGenreById(genreId);

            if (genre is null)
                return NotFound();

            return genre;
        }

        [HttpPost]
        public IActionResult Create(GameGenre genre)
        {
            var newGenre = _service.CreateGenre(genre);
            return CreatedAtAction(nameof(Create), new { id = genre.Id }, genre);
        }

        [HttpPut]
        public IActionResult Update(GameGenre genre)
        {
            var genreId = genre.Id;
            if (genre is null)
                return BadRequest();

            if (genreId != genre.Id)
                return BadRequest();

            var existingGame = _service.GetGenreById(genreId);
            if (existingGame is null)
                return NotFound();

            _service.UpdateGenre(genre);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _service.GetGenreById(id);

            if (game is null)
                return NotFound();

            _service.DeleteGenreById(id);

            return NoContent();
        }
    }
}
