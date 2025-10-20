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
               
                var winners = await _context.Scorecards
                    .GroupBy(s => s.GameId)
                    .Select(s =>
                        s.OrderByDescending(s =>
                                (s.Ones + s.Twos + s.Threes + s.Fours + s.Fives + s.Sixes) +
                                ((s.Ones + s.Twos + s.Threes + s.Fours  + s.Fives + s.Sixes) > 63 ? 35 : 0) +
                                s.ThreeOfAKind +
                                s.FourOfAKind +
                                (s.FullHouse ? 25 : 0) +
                                (s.SmStraight ? 30 : 0) +
                                (s.LgStraight ? 40 : 0) + 
                                (s.Yahtzee ? 50 : 0) +
                                (s.BonusYahtzees * 100) +
                                s.Chance
                            ).FirstOrDefault().PlayerId)
                    .ToListAsync();

                var winsByPlayer = winners
                    .GroupBy(id => id)
                    .ToDictionary(w => w.Key, w => w.Count());

                foreach (var player in players)
                {
                    int grandTotal = 0;
                    
                    int gamesPlayed = await _context.Scorecards
                        .Where(s => s.PlayerId == player.Id)
                        .CountAsync();
                    
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
                    
                    foreach (var score in scores)
                    {
                        var upperBonus = score.Upper >= 63 ? 35 : 0;
                        grandTotal += score.Upper + score.Lower + upperBonus;
                    }

                    summaries.Add(new PlayerSummaryDto
                    {
                        Id = player.Id,
                        Name = player.Name,
                        GrandTotal = grandTotal,
                        GamesPlayed = gamesPlayed,
                        Wins = winsByPlayer[player.Id]
                    });
                }

                return summaries;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<IEnumerable<MostRecentGameDto>> GetMostRecentGamesAsync()
        {
            try
            {
                var players = await _context.Players.ToListAsync();
                var mostRecentGames = new List<MostRecentGameDto>();

                foreach (var player in players)
                {
                    var lastGame = _context.Scorecards
                        .Where(s => s.PlayerId == player.Id)
                        .OrderByDescending(s => s.GameId)
                        .FirstOrDefault();
                    
                    int upperTotal = 
                        lastGame.Ones + 
                        lastGame.Twos + 
                        lastGame.Threes + 
                        lastGame.Fours + 
                        lastGame.Fives + 
                        lastGame.Sixes;
                    int upperBonus = (upperTotal >= 63) ? 35 : 0; 
                    
                    int lowerTotal =
                        lastGame.ThreeOfAKind +
                        lastGame.FourOfAKind +
                        (lastGame.FullHouse ? 25 : 0) +
                        (lastGame.SmStraight ? 30 : 0) +
                        (lastGame.LgStraight ? 40 : 0) +
                        (lastGame.Yahtzee ? 50 : 0) +
                        (lastGame.BonusYahtzees * 100) +
                        lastGame.Chance;
                    
                    mostRecentGames.Add(new MostRecentGameDto
                    {
                        PlayerId = player.Id,
                        PlayerName = player.Name,
                        Ones = lastGame.Ones,
                        Twos = lastGame.Twos,
                        Threes = lastGame.Threes,
                        Fours = lastGame.Fours,
                        Fives = lastGame.Fives,
                        Sixes = lastGame.Sixes,
                        UpperBonus = upperBonus,
                        UpperTotal = upperTotal + upperBonus,
                        
                        ThreeOfAKind = lastGame.ThreeOfAKind,
                        FourOfAKind = lastGame.FourOfAKind,
                        FullHouse = lastGame.FullHouse ? 25 : 0,
                        SmStraight = lastGame.SmStraight ? 30 : 0,
                        LgStraight = lastGame.LgStraight ? 40 : 0,
                        Yahtzee = lastGame.Yahtzee ? 50 : 0,
                        BonusYahtzees = lastGame.BonusYahtzees,
                        Chance = lastGame.Chance,
                        
                        LowerTotal = lowerTotal,
                        GrandTotal = upperTotal + upperBonus + lowerTotal
                    });
                } 
                return mostRecentGames;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        public async Task<AverageScoresDto> GetAverageScorecardAsync(int playerId)
        {
            try
            {
                var scorecards = await _mapper.ProjectTo<ScorecardDto>(
                        _context.Scorecards
                    )
                    .Where(s => s.PlayerId == playerId)
                    .AsNoTracking()
                    .ToListAsync();
                
                int averageOnes = (int)scorecards
                    .Select(s => s.Ones)
                    .ToList()
                    .Average();
                int averageTwos = (int)scorecards
                    .Select(s => s.Twos / 2)
                    .ToList()
                    .Average() * 2;
                int averageThrees = (int)scorecards
                    .Select(s => s.Threes / 3)
                    .ToList()
                    .Average() * 3;
                int averageFours = (int)scorecards
                    .Select(s => s.Fours / 4)
                    .ToList()
                    .Average() * 4;
                int averageFives = (int)scorecards
                    .Select(s => s.Fives / 5)
                    .ToList()
                    .Average() * 5;
                int averageSixes = (int)scorecards
                    .Select(s => s.Sixes / 6)
                    .ToList()
                    .Average() * 6;

                return new AverageScoresDto
                {
                    PlayerId = playerId,
                    Ones = averageOnes,
                    Twos = averageTwos,
                    Threes = averageThrees,
                    Fours = averageFours,
                    Fives = averageFives,
                    Sixes = averageSixes
                };
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }
    }
}