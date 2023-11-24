using System.Reflection.Metadata.Ecma335;
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


        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetGame(int id)
        {
            var dbVideoGame = await _db.VideoGames.FindAsync(id);
            if (dbVideoGame == null) return NotFound("video not found");
            return Ok(dbVideoGame);
        }

        [HttpPost]
        public async Task<ActionResult<List<VideoGame>>> CreateVideoGame(VideoGame videoGame)
        {
            _db.VideoGames.Add(videoGame);
            await _db.SaveChangesAsync();
            return await GetAllVideoGames();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<VideoGame>>> UpdateVideoGame(int id, VideoGame videoGame)
        {
            var dbVideoGame = await _db.VideoGames.FindAsync(id);
            if (dbVideoGame == null) return NotFound("Video not found");
            dbVideoGame.Title = videoGame.Title;
            dbVideoGame.ReleaseYear = videoGame.ReleaseYear;
            dbVideoGame.Publisher = videoGame.Publisher;
            await _db.SaveChangesAsync();
            return await GetAllVideoGames();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VideoGame>>> DeleteVideoGame(int id)
        {
            var dbVideoGame = await _db.VideoGames.FindAsync(id);
            if (dbVideoGame == null) return NotFound("Video not found");

            _db.VideoGames.Remove(dbVideoGame);

            await _db.SaveChangesAsync();
            return await GetAllVideoGames();
        }
    }
}