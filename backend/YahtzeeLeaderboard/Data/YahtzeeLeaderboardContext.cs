using Microsoft.EntityFrameworkCore;
using YahtzeeLeaderboard.Models;

namespace YahtzeeLeaderboard.Data
{
    public class YahtzeeLeaderboardContext : DbContext
    {
        public YahtzeeLeaderboardContext(DbContextOptions<YahtzeeLeaderboardContext> options) : base(options) { }
        
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Scorecard> Scorecards => Set<Scorecard>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Scorecard>()
                .HasKey(sc => new { sc.GameId, sc.PlayerId });
        }
    }
}