using AprikordGames.Interfaces;
using AprikordGames.Models;
using AprikordGames.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AprikordGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        IGameService _service;
        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Game> GetAllGames() => _service.GetAllGames();

        [HttpGet("{Id}")]
        public ActionResult<Game> Get(int Id)
        {
            var game = _service.GetGameById(Id);

            if (game is null)
                return NotFound();

            return game;
        }
        
        [HttpPost]
        public IActionResult Create(Game game)
        {
            var newGame = _service.CreateGame(game);
            return CreatedAtAction(nameof(Create), new { id = game.Id }, game);
        }

        [HttpPut]
        public IActionResult Update(Game game)
        {
            var id = game.Id;
            if (game is null)
                return BadRequest();

            if (id != game.Id)
                return BadRequest();

            var existingGame = _service.GetGameById(id);
            if (existingGame is null)
                return NotFound();

            _service.UpdateGame(game);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _service.GetGameById(id);

            if (game is null)
                return NotFound();

            _service.DeleteGameById(id);

            return NoContent();
        }

        [HttpGet]
        [Route("/GamesByGenre/{genreId}")]
        public IEnumerable<Game> GamesByGenre(int genreId) => _service.GetGamesByGenreId(genreId);
    }
}
