using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrudDotNet8.Entities;

namespace BlazorCrudDotNet8.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGamesAsync();   
    }
}