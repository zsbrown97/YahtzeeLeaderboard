using AutoMapper;
using Microsoft.EntityFrameworkCore;

using YahtzeeLeaderboard.Data;
using YahtzeeLeaderboard.Dtos;
using YahtzeeLeaderboard.Interfaces;

namespace YahtzeeLeaderboard.Services
{
    public class GameService : IGameService
    {
        private readonly YahtzeeLeaderboardContext _context;
        private readonly IMapper _mapper;

        public GameService(YahtzeeLeaderboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            try
            {
                return await _mapper.ProjectTo<GameDto>
                    (
                        _context.Games
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<IEnumerable<GameDto>> GetGamesByDateAsync(DateTime date)
        {
            try
            {
                return await _mapper.ProjectTo<GameDto>
                    (
                        _context.Games
                    )
                    .Where(g => g.Date.Date == date.Date)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<IEnumerable<GameDto>> GetGamesByPlayerIdAsync(int playerId)
        {
            try
            {
                return await _mapper.ProjectTo<GameDto>(_context.Games)
                    .Where(g =>
                        g.PlayerOne == playerId ||
                        g.PlayerTwo == playerId ||
                        g.PlayerThree == playerId ||
                        g.PlayerFour == playerId ||
                        g.PlayerFive == playerId ||
                        g.PlayerSix == playerId
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }
    }
}

