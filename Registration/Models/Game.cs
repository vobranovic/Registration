using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }
        public int PlayersRegistered { get; set; }
        public bool LoggedUserRegistered { get; set; }

        [ForeignKey("GameId")]
        public List<GameApplicationUser> GameApplicationUsers { get; set; } = new List<GameApplicationUser>();
        
    }
}
