using YahtzeeLeaderboard.Dtos;

namespace YahtzeeLeaderboard.Services
{
    public interface IScorecardService
    {
        Task<IEnumerable<ScorecardDto>> GetAllScorecardsAsync();
        Task<ScoreSummaryDto> GetScorecardTotalsAsync(int gameId, int playerId);
    }
}