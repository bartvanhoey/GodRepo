using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using SimpleVideoGameLibrary.Shared;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly DataContext _db;

        public VideoGameController(DataContext context)
        {
            _db = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames()
        {

            var videoGames = await _db.VideoGames.OrderBy(g => g.ReleaseYear).ToListAsync();


            return Ok(videoGames);
        }
    }
}