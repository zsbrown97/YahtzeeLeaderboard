using Microsoft.AspNetCore.Mvc;

using YahtzeeLeaderboard.Dtos;
using YahtzeeLeaderboard.Interfaces;

namespace YahtzeeLeaderboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
        {
            var result = await _playerService.GetPlayersAsync();
            return Ok(result);
        }

        [HttpGet("playerSummaries")]
        public async Task<ActionResult<IEnumerable<PlayerSummaryDto>>> GetPlayerSummaries()
        {
            var result = await _playerService.GetPlayerSummariesAsync();
            return Ok(result);
        }

        [HttpGet("mostRecentGames")]
        public async Task<ActionResult<IEnumerable<PlayerScorecardDto>>> GetMostRecentGames()
        {
            var result = await _playerService.GetMostRecentGamesAsync();
            return Ok(result);
        }

        [HttpGet("averageScorecard/{id}")]
        public async Task<ActionResult<PlayerScorecardDto>> GetAverageScorecard([FromRoute] int id)
        {
            var result = await _playerService.GetAverageScorecardAsync(id);
            return Ok(result);
        }
    }
}