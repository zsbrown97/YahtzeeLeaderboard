using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Dtos
{
    public class PlayerScorecardDto
    {
        [Required]
        public int PlayerId { get; set; }
        [Required] 
        public string PlayerName { get; set; }
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
        public int UpperBonus { get; set; }
        [Required]
        public int UpperTotal { get; set; }
        [Required]
        public int ThreeOfAKind { get; set; }
        [Required]
        public int FourOfAKind { get; set; }
        [Required]
        public int FullHouse { get; set; }
        [Required] 
        public int SmStraight { get; set; }
        [Required]
        public int LgStraight { get; set; }
        [Required]
        public int Yahtzee { get; set; }
        [Required] 
        [Range(0, 3)] 
        public int BonusYahtzees { get; set; }
        [Required]
        public int Chance { get; set; }
        [Required]
        public int LowerTotal { get; set; }
        [Required] 
        public int GrandTotal { get; set; }

    }
}