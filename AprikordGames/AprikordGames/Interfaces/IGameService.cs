using AprikordGames.Models;
using System.Collections.Generic;

namespace AprikordGames.Interfaces
{
    public interface IGameService
    {
        public IEnumerable<Game> GetAllGames();

        public Game GetGameById(int gameId);

        public Game CreateGame(Game newGame);

        public void UpdateGame(Game game);

        public void DeleteGameById(int gameId);

        public IEnumerable<Game> GetGamesByGenreId(int genreId);
    }
}
