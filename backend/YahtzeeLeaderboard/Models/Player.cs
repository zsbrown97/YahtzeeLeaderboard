using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Models
{
    public class Player
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}