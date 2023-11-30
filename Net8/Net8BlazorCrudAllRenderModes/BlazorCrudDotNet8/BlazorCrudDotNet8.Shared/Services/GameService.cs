using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _db;

        public GameService(DataContext context)
        {
            _db = context;
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
            return game;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            await Task.Delay(2000);

            var games = await _db.Games.ToListAsync();

            return games; ;
        }

        public async Task<Game> GetGameById(int id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);
            return game;
        }
    }
}