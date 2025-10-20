

using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Dtos
{
    public class ScorecardDto
    {
        [Required]
        public int GameId { get; set; }
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
        [Required]
        public int ThreeOfAKind { get; set; }
        [Required]
        public int FourOfAKind { get; set; }
        [Required] 
        public bool FullHouse { get; set; }
        [Required]
        public bool SmStraight { get; set; }
        [Required]
        public bool LgStraight { get; set; }
        [Required]
        public bool Yahtzee { get; set; }
        [Required]
        [Range(0,3)]
        public int BonusYahtzees { get; set; }
        [Required]
        public int Chance { get; set; }
    }
}