using AutoMapper;
using Microsoft.EntityFrameworkCore;

using YahtzeeLeaderboard.Data;
using YahtzeeLeaderboard.Dtos;

namespace YahtzeeLeaderboard.Services
{
    public class ScorecardService : IScorecardService
    {
        private readonly YahtzeeLeaderboardContext _context;
        private readonly IMapper _mapper;

        public ScorecardService(YahtzeeLeaderboardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScorecardDto>> GetAllScorecardsAsync()
        {
            try
            {
                return await _mapper.ProjectTo<ScorecardDto>(
                    _context.Scorecards
                )
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<ScoreSummaryDto> GetScorecardTotalsAsync(int gameId, int playerId)
        {
            try
            {
                var scores = await _context.Scorecards
                    .Where(s =>
                        s.GameId == gameId &&
                        s.PlayerId == playerId
                    )
                    .Select(s => new
                    {
                        s.Player.Name,
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
                    .FirstOrDefaultAsync();
                var upperTotalWithBonus = 
                    scores.Upper >= 63 
                        ? scores.Upper + 35 
                        : scores.Upper;

                return new ScoreSummaryDto
                {
                    PlayerName = scores.Name,
                    UpperTotal = upperTotalWithBonus,
                    LowerTotal = scores.Lower,
                    GrandTotal = upperTotalWithBonus + scores.Lower
                };
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<int> GetUpperTotalAsync(int gameId, int playerId)
        {
            try
            {
                var upperScore = await _context.Scorecards
                    .Where(s =>
                        s.GameId == gameId &&
                        s.PlayerId == playerId
                    )
                    .Select(s =>
                        s.Ones +
                        s.Twos +
                        s.Threes +
                        s.Fours +
                        s.Fives +
                        s.Sixes
                    )
                    .FirstOrDefaultAsync();

                if (upperScore >= 63) upperScore += 35;
                
                return upperScore;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<int> GetLowerTotalAsync(int gameId, int playerId)
        {
            try
            {
                var lowerScore = await _context.Scorecards
                    .Where(s =>
                        s.GameId == gameId &&
                        s.PlayerId == playerId
                    )
                    .Select(s =>
                        s.ThreeOfAKind +
                        s.FourOfAKind +
                        (s.FullHouse ? 25 : 0) +
                        (s.SmStraight ? 30 : 0) +
                        (s.LgStraight ? 40 : 0) +
                        (s.Yahtzee ? 50 : 0) +
                        (s.BonusYahtzees * 100) +
                        s.Chance
                    )
                    .FirstOrDefaultAsync();

                return lowerScore;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }
    }
}