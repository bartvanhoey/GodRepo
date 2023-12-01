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

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await _db.Games.FindAsync(id);
            if (game != null)
            {
                _db.Games.Remove(game);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<Game> EditGameAsync(int id, Game game)
        {
            var dbGame = await _db.Games.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.Name = game.Name;
                await _db.SaveChangesAsync();
                return dbGame;
            }
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