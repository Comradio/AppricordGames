using AprikordGames.Models;
using Microsoft.EntityFrameworkCore;

namespace AprikordGames.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<GameDeveloperStudio> DeveloperStudios => Set<GameDeveloperStudio>();
        public DbSet<GameGenre> Genres => Set<GameGenre>();
    }
}
