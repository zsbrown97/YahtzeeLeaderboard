using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Dtos
{
    public class AverageScoresDto
    {
        [Required] 
        public int PlayerId { get; set; }
        [Required]
        public int Ones { get; set; }
        [Required]
        public int Twos { get; set; }
        [Required]
        public int Threes { get; set; }
        [Required]
        public int Fours { get; set; }
        [Required]
        public int Fives { get; set; }
        [Required]
        public int Sixes { get; set; }
    }
}