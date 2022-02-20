using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AprikordGames.Models
{
    public class GameGenre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }
        [JsonIgnore]
        public ICollection<Game>? Games { get; set; }
    }
}
