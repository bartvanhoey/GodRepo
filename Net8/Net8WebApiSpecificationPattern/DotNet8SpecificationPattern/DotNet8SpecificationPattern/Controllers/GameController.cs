using DotNet8SpecificationPattern.Entities;
using DotNet8SpecificationPattern.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8SpecificationPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameService  )
        {
            _gameRepository = gameService;
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAllGames(){
            return  _gameRepository.GetAllGames();
        }

    }
}
