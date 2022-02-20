using AprikordGames.Data;
using AprikordGames.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AprikordGames.Interfaces;

namespace AprikordGames.Services
{
    public class GameService : IGameService
    {
        private readonly GameContext _context;

        public GameService(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games
                .AsNoTracking() //так как операция только для чтения, можно отключить отслеживание измнений
                .Include(g => g.DeveloperStudio)
                .Include(g => g.Genres)
                .ToList();
        }

        public IEnumerable<Game> GetGamesByGenreId(int genreId)
        {
            var genre = _context.Genres.Find(genreId);

            if (genre == null)
                return Enumerable.Empty<Game>();
                

            return _context.Games
                .AsNoTracking()
                .Where(g => g.Genres.Contains(genre))
                .Include(g => g.DeveloperStudio)
                .Include(g => g.Genres)
                .ToList();
        }

        public Game GetGameById(int gameId)
        {
            return _context.Games
                .AsNoTracking()
                .Include(g => g.DeveloperStudio)
                .Include(g => g.Genres)
                .SingleOrDefault(p => p.Id == gameId);
        }

        public Game CreateGame(Game newGame)
        {
            _context.Games.Add(newGame);
            _context.SaveChanges();

            return newGame;
        }

        public void UpdateGame(Game game)
        {
            var gameToUpdate = _context.Games
                               .AsNoTracking()
                               .SingleOrDefault(p => p.Id == game.Id);

            if (gameToUpdate is null || game is null)
            {
                throw new NullReferenceException("Game does not exists");
            }

            gameToUpdate = game;
            
            _context.Games.Update(gameToUpdate);
            _context.SaveChanges();
        }

        public void DeleteGameById(int gameId)
        {
            var gameToDelete = _context.Games.Find(gameId);
            if (!(gameToDelete is null))
            {
                _context.Games.Remove(gameToDelete);
                _context.SaveChanges();
            }
        }
    }
}
