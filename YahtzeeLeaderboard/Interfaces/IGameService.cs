using YahtzeeLeaderboard.Dtos;

namespace YahtzeeLeaderboard.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllGamesAsync();
        Task<IEnumerable<GameDto>> GetGamesByDateAsync(DateTime date);
        Task<IEnumerable<GameDto>> GetGamesByPlayerIdAsync(int playerId);
    }
}