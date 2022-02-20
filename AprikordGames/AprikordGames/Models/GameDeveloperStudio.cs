using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AprikordGames.Models
{
    public class GameDeveloperStudio
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string StudioName { get; set; }
    }
}
