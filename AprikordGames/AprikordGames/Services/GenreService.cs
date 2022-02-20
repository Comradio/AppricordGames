using AprikordGames.Data;
using AprikordGames.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AprikordGames.Interfaces;

namespace AprikordGames.Services
{
    public class GenreService : IGenreService
    {
        private readonly GameContext _context;

        public GenreService(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<GameGenre> GetAllGenres()
        {
            return _context.Genres
                .AsNoTracking() //так как операция только для чтения, можно отключить отслеживание измнений
                .ToList();
        }

        public GameGenre GetGenreById(int genreId)
        {
            return _context.Genres
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == genreId);
        }

        public GameGenre CreateGenre(GameGenre newGenre)
        {
            _context.Genres.Add(newGenre);
            _context.SaveChanges();

            return newGenre;
        }

        public void UpdateGenre(GameGenre gameGenre)
        {
            var genreToUpdate = _context.Genres
                                .AsNoTracking()
                                .SingleOrDefault(p => p.Id == gameGenre.Id);

            if (genreToUpdate is null || gameGenre is null)
            {
                throw new NullReferenceException("Genre does not exists");
            }

            genreToUpdate = gameGenre;
            _context.Genres.Update(genreToUpdate);
            _context.SaveChanges();
        }

        public void DeleteGenreById(int genreId)
        {
            var genreToDelete = _context.Genres.Find(genreId);
            if (!(genreToDelete is null))
            {
                _context.Genres.Remove(genreToDelete);
                _context.SaveChanges();
            }
        }
    }
}
