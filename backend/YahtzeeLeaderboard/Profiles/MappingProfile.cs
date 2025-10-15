using AutoMapper;

using YahtzeeLeaderboard.Dtos;
using YahtzeeLeaderboard.Models;

namespace YahtzeeLeaderboard.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Player
            CreateMap<Player, PlayerDto>().ReverseMap();
            
            // Game
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<CreateGameDto, Game>();
            
            // Scorecard
            CreateMap<Scorecard, ScorecardDto>().ReverseMap();

        }
    }
}