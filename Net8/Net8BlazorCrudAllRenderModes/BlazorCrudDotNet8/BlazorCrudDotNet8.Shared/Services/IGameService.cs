using BlazorCrudDotNet8.Shared.Entities;

namespace BlazorCrudDotNet8.Shared.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGamesAsync();   
        Task<Game> AddGameAsync(Game game);   
    }
}