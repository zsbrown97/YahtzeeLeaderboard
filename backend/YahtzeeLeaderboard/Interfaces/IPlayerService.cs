using YahtzeeLeaderboard.Dtos;

namespace YahtzeeLeaderboard.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetPlayersAsync();
    }
}