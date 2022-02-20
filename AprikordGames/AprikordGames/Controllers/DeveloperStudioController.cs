using AprikordGames.Interfaces;
using AprikordGames.Models;
using AprikordGames.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AprikordGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperStudioController : ControllerBase
    {
        IDeveloperStudioService _service;

        public DeveloperStudioController(IDeveloperStudioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<GameDeveloperStudio> GetAllDeveloperStudios() => _service.GetAllDeveloperStudios();

        [HttpGet("{developerStudioId}")]
        public ActionResult<GameDeveloperStudio> Get(int developerStudioId)
        {
            var developerStudio = _service.GetDeveloperStudioById(developerStudioId);

            if (developerStudio is null)
                return NotFound();

            return developerStudio;
        }

        [HttpPost]
        public IActionResult Create(GameDeveloperStudio developerStudio)
        {
            var newDeveloperStudio = _service.CreateDeveloperStudio(developerStudio);
            return CreatedAtAction(nameof(Create), new { id = developerStudio.Id }, developerStudio);
        }

        [HttpPut]
        public IActionResult Update(GameDeveloperStudio developerStudio)
        {
            var developerStudioId = developerStudio.Id;
            if (developerStudio is null)
                return BadRequest();

            if (developerStudioId != developerStudio.Id)
                return BadRequest();

            var existingGame = _service.GetDeveloperStudioById(developerStudioId);
            if (existingGame is null)
                return NotFound();

            _service.UpdateDeveloperStudio(developerStudio);

            return NoContent();
        }

        [HttpDelete("{developerStudioId}")]
        public IActionResult Delete(int developerStudioId)
        {
            var game = _service.GetDeveloperStudioById(developerStudioId);

            if (game is null)
                return NotFound();

            _service.DeleteDeveloperStudioById(developerStudioId);

            return NoContent();
        }
    }
}
