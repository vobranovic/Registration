using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Models
{
    public class GameApplicationUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
