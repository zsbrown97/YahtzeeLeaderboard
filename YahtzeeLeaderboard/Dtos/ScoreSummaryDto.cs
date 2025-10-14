using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Dtos
{
    public class ScoreSummaryDto
    {
        [Required]
        public string PlayerName { get; set; }
        [Required]
        public int UpperTotal { get; set; }
        [Required]
        public int LowerTotal { get; set; }
        [Required]
        public int GrandTotal { get; set; }
    }
}