using AprikordGames.Models;
using System.Collections.Generic;

namespace AprikordGames.Interfaces
{
    public interface IDeveloperStudioService
    {
        public IEnumerable<GameDeveloperStudio> GetAllDeveloperStudios();

        public GameDeveloperStudio GetDeveloperStudioById(int developerStudioId);

        public GameDeveloperStudio CreateDeveloperStudio(GameDeveloperStudio newDeveloperStudio);

        public void UpdateDeveloperStudio(GameDeveloperStudio gameDeveloperStudio);

        public void DeleteDeveloperStudioById(int developerStudioId);
    }
}
