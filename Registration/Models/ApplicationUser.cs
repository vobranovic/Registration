using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nickname { get; set; }

        [ForeignKey("UserId")]
        public List<GameApplicationUser> GameApplicationUsers { get; set; }
    }
}
