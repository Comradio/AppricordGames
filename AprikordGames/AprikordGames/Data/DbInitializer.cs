using AprikordGames.Models;
using System.Collections.Generic;
using System.Linq;

namespace AprikordGames.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameContext context)
        {
            if (!context.Games.Any() || !context.Genres.Any() || !context.DeveloperStudios.Any())
            {
                var metroidvania = new GameGenre { Genre = "Метроидвания" };
                var rpg = new GameGenre { Genre = "Ролевая игра" };
                var indi = new GameGenre { Genre = "Инди" };
                var quest = new GameGenre { Genre = "Квест" };
                var puzzle = new GameGenre { Genre = "Головоломка" };
                var adventure = new GameGenre { Genre = "Приключение" };
                var actionAdventure = new GameGenre { Genre = "Приключенческий боевик" };
                var fighting = new GameGenre { Genre = "Файтинг" };
                var fantasy = new GameGenre { Genre = "Фэнтези" };
                var openWorld = new GameGenre { Genre = "Открытый мир" };

                var freebirdGames = new GameDeveloperStudio { StudioName = "Freebird Games" };
                var hazelightStudios = new GameDeveloperStudio { StudioName = "Hazelight Studios" };
                var teamCherry = new GameDeveloperStudio { StudioName = "Team Cherry" };
                var bethesdaGameStudios = new GameDeveloperStudio { StudioName = "Bethesda Game Studios" };
                var cdProjektRED = new GameDeveloperStudio { StudioName = "CD Projekt RED" };

                var games = new Game[]
                {
                new Game
                {
                    Name = "To the Moon",
                    DeveloperStudio = freebirdGames,
                    Genres = new List<GameGenre>
                        {
                            rpg,
                            indi,
                            quest,
                            puzzle,
                            adventure
                        }
                },
                new Game
                {
                    Name = "It Takes Two",
                    DeveloperStudio = hazelightStudios,
                    Genres = new List<GameGenre>
                        {
                            puzzle,
                            actionAdventure
                        }
                },
                new Game
                {
                    Name = "Hollow Knight",
                    DeveloperStudio = teamCherry,
                    Genres = new List<GameGenre>
                        {
                            metroidvania,
                            fighting
                        }
                },
                new Game
                {
                    Name = "The Elder Scrolls V: Skyrim",
                    DeveloperStudio = bethesdaGameStudios,
                    Genres = new List<GameGenre>
                        {
                            openWorld,
                            fantasy,
                            rpg,
                            actionAdventure
                        }
                },
                new Game
                {
                    Name = "Ведьмак 3: Дикая Охота",
                    DeveloperStudio = cdProjektRED,
                    Genres = new List<GameGenre>
                        {
                            openWorld,
                            fantasy,
                            rpg,
                            actionAdventure,
                            fighting
                        }
                }

                };

                context.Games.AddRange(games);
                context.SaveChanges();
            }
        }
    }
}
