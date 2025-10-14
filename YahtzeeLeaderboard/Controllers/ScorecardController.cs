using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using YahtzeeLeaderboard.Data;
using YahtzeeLeaderboard.Dtos;
using YahtzeeLeaderboard.Models;
using YahtzeeLeaderboard.Services;

namespace YahtzeeLeaderboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScorecardController : ControllerBase
    {
        IScorecardService _scorecardService;

        public ScorecardController(IScorecardService scorecardService)
        {
            _scorecardService = scorecardService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scorecard>>> GetScorecards()
        {
            var result = await _scorecardService.GetAllScorecardsAsync();
            return Ok(result);
        }

        [HttpGet("upperTotal/{gameId}/{playerId}")]
        public async Task<ActionResult<int>> GetUpperTotal([FromRoute] int gameId, [FromRoute] int playerId)
        {
            var result = await _scorecardService.GetUpperTotalAsync(gameId, playerId);
            return Ok(result);
        }

        [HttpGet("lowerTotal/{gameId}/{playerId}")]
        public async Task<ActionResult<int>> GetLowerTotal([FromRoute] int gameId, [FromRoute] int playerId)
        {
            var result = await _scorecardService.GetLowerTotalAsync(gameId, playerId);
            return Ok(result);
        }
    }
}