using AprikordGames.Models;
using System.Collections.Generic;

namespace AprikordGames.Interfaces
{
    public interface IGenreService
    {
        public IEnumerable<GameGenre> GetAllGenres();

        public GameGenre GetGenreById(int genreId);

        public GameGenre CreateGenre(GameGenre newGenre);

        public void UpdateGenre(GameGenre gameGenre);

        public void DeleteGenreById(int genreId);
    }
}
