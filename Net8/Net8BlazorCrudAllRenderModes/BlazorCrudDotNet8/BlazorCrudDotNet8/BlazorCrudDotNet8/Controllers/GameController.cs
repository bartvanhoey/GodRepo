using BlazorCrudDotNet8.Shared.Entities;
using BlazorCrudDotNet8.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            var addedGame = await _gameService.AddGameAsync(game);
            return Ok(addedGame);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Game>> EditGame(int id, Game game)
        {
            var editedGame = await _gameService.EditGameAsync(id, game);
            return Ok(editedGame);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteGame(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            return Ok(result);
        }

        
        


         [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _gameService.GetGameById(id);
            return Ok(game);
        }
    }
}