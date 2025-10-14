using System.ComponentModel.DataAnnotations;

namespace YahtzeeLeaderboard.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        [Required]
        public int PlayerOne { get; set; }
        public int?  PlayerTwo { get; set; }
        public int?  PlayerThree { get; set; }
        public int?  PlayerFour { get; set; }
        public int?  PlayerFive { get; set; }
        public int?  PlayerSix { get; set; }
        
        public List<Scorecard> Scorecards { get; set; } = new List<Scorecard>();
    }
}