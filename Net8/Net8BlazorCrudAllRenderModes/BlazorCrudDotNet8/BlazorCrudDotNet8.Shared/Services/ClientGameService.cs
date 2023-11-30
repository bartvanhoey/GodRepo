using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorCrudDotNet8.Shared.Entities;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class ClientGameService : IGameService
    {
        private readonly HttpClient _http;

        public ClientGameService(HttpClient http)
        {
            _http = http;
        }


        public async Task<Game> AddGameAsync(Game game)
        {
            var response = await _http.PostAsJsonAsync("/api/game", game);
            // response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Game>();
            return result;
        }

        public Task<List<Game>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetGameById(int id)
        {
            var response = await _http.GetFromJsonAsync<Game>($"api/game/{id}");
            return response;

            
        }
    }
}