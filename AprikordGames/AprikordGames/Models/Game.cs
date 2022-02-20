using AprikordGames.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AprikordGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public GameDeveloperStudio? DeveloperStudio { get; set; }
        public ICollection<GameGenre>? Genres { get; set; }
    }
}
