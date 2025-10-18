using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Dtos
{
    public class PlayerSummaryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int GrandTotal { get; set; }
        [Required]
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
    }
}