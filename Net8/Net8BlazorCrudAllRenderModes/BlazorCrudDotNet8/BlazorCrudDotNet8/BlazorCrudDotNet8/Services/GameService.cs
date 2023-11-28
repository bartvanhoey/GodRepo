using BlazorCrudDotNet8.Data;
using BlazorCrudDotNet8.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Services
{
    public class GameService : IGameService
    {
        private readonly DataContext _db;

        public GameService(DataContext context)
        {
            _db = context;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            await Task.Delay(2000);

            var games = await _db.Games.ToListAsync();

            return games; ;
        }
    }
}