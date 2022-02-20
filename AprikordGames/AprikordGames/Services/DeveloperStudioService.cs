using AprikordGames.Data;
using AprikordGames.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AprikordGames.Interfaces;

namespace AprikordGames.Services
{
    public class DeveloperStudioService : IDeveloperStudioService
    {
        private readonly GameContext _context;

        public DeveloperStudioService(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<GameDeveloperStudio> GetAllDeveloperStudios()
        {
            return _context.DeveloperStudios
                .AsNoTracking() //так как операция только для чтения, можно отключить отслеживание измнений
                .ToList();
        }

        public GameDeveloperStudio GetDeveloperStudioById(int developerStudioId)
        {
            return _context.DeveloperStudios
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == developerStudioId);
        }

        public GameDeveloperStudio CreateDeveloperStudio(GameDeveloperStudio newDeveloperStudio)
        {
            _context.DeveloperStudios.Add(newDeveloperStudio);
            _context.SaveChanges();

            return newDeveloperStudio;
        }

        public void UpdateDeveloperStudio(GameDeveloperStudio gameDeveloperStudio)
        {
            var developerStudioToUpdate = _context.DeveloperStudios
                                          .AsNoTracking()
                                          .SingleOrDefault(p => p.Id == gameDeveloperStudio.Id);

            if (developerStudioToUpdate is null || gameDeveloperStudio is null)
            {
                throw new NullReferenceException("Developer studio does not exists");
            }

            developerStudioToUpdate = gameDeveloperStudio;
            _context.DeveloperStudios.Update(developerStudioToUpdate);
            _context.SaveChanges();
        }

        public void DeleteDeveloperStudioById(int developerStudioId)
        {
            var developerStudioToDelete = _context.DeveloperStudios.Find(developerStudioId);
            if (!(developerStudioToDelete is null))
            {
                _context.DeveloperStudios.Remove(developerStudioToDelete);
                _context.SaveChanges();
            }
        }
    }
}
