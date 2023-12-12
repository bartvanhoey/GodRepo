using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet8SpecificationPattern.Entities;
using DotNet8SpecificationPattern.Specification;

namespace DotNet8SpecificationPattern.Repositories
{
    public interface IGameRepository
    {
            List<Game> GetAllGames();
            List<Game> GetGames(Specification<Game> specification);
    }
}