using YahtzeeLeaderboard.Dtos;

namespace YahtzeeLeaderboard.Services
{
    public interface IScorecardService
    {
        Task<IEnumerable<ScorecardDto>> GetAllScorecardsAsync();
        Task<int> GetUpperTotalAsync(int gameId, int playerId);
        Task<int> GetLowerTotalAsync(int gameId, int playerId);
        //Task<int> GetFinalScoreAsync(int gameId, int playerId);
    }
}