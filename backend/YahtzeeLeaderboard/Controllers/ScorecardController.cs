using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("summary/{gameId}-{playerId}")]
        public async Task<ActionResult<ScoreSummaryDto>> GetScorecardTotals(
            [FromRoute] int gameId,
            [FromRoute] int playerId
        )
        {
            var result = await _scorecardService.GetScorecardTotalsAsync(gameId, playerId);
            return Ok(result);
        }
    }
}