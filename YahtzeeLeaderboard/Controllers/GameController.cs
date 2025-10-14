using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using YahtzeeLeaderboard.Data;
using YahtzeeLeaderboard.Dtos;
using YahtzeeLeaderboard.Interfaces;
using YahtzeeLeaderboard.Models;

namespace YahtzeeLeaderboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        IGameService _gameService;
        
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            var result = await _gameService.GetAllGamesAsync();
            return Ok(result);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGamesByDate([FromRoute] DateTime date)
        {
            var result = await _gameService.GetGamesByDateAsync(date);
            return Ok(result);
        }

        [HttpGet("player/{playerId}")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGamesByPlayerId([FromRoute] int playerId)
        {
            var result = await _gameService.GetGamesByPlayerIdAsync(playerId);
            return Ok(result);
        }

    }
}