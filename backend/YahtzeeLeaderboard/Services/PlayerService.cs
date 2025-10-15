using AutoMapper;
using Microsoft.EntityFrameworkCore;

using YahtzeeLeaderboard.Data;
using YahtzeeLeaderboard.Dtos;
using YahtzeeLeaderboard.Interfaces;

namespace YahtzeeLeaderboard.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly YahtzeeLeaderboardContext _context;
        private readonly IMapper _mapper;

        public PlayerService(YahtzeeLeaderboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
        {
            try
            {
                return await _mapper.ProjectTo<PlayerDto>
                    (
                        _context.Players
                    )
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
            
        }
        
        public async Task<IEnumerable<PlayerSummaryDto>> GetPlayerSummariesAsync()
        {
            try
            {
                var players = await _context.Players.ToListAsync();
                var summaries = new List<PlayerSummaryDto>();

                foreach (var player in players)
                {
                    var scores = await _context.Scorecards
                        .Where(s => s.PlayerId == player.Id)
                        .Select(s => new
                        {
                            Upper =
                                s.Ones +
                                s.Twos +
                                s.Threes +
                                s.Fours +
                                s.Fives +
                                s.Sixes,
                            Lower =
                                s.ThreeOfAKind +
                                s.FourOfAKind +
                                (s.FullHouse ? 25 : 0) +
                                (s.SmStraight ? 30 : 0) +
                                (s.LgStraight ? 40 : 0) +
                                (s.Yahtzee ? 50 : 0) +
                                s.Chance +
                                (s.BonusYahtzees * 100)
                        })
                        .ToListAsync();
                    var grandTotal = 0;
                    foreach (var score in scores)
                    {
                        var upperBonus = score.Upper >= 63 ? 35 : 0;
                        grandTotal += score.Upper + score.Lower + upperBonus;
                    }

                    summaries.Add(new PlayerSummaryDto
                    {
                        Id = player.Id,
                        Name = player.Name,
                        GrandTotal = grandTotal
                    });
                }

                return summaries;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
            
        }
    }
}