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
    }
}