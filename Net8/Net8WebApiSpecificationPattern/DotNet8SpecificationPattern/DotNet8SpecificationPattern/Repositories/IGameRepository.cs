using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet8SpecificationPattern.Entities;

namespace DotNet8SpecificationPattern.Repositories
{
    public interface IGameRepository
    {
            List<Game> GetAllGames();
    }
}