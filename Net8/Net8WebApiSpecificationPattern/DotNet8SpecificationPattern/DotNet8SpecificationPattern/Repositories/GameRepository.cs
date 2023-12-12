using DotNet8SpecificationPattern.Data;
using DotNet8SpecificationPattern.Entities;
using DotNet8SpecificationPattern.Specification;
using Microsoft.EntityFrameworkCore;

namespace DotNet8SpecificationPattern.Repositories
{
    public class GameRepository(DataContext db) : IGameRepository
    {
        public List<Game> GetAllGames()
        {
            // return db.Games
            //     .Where(g => g.Genre.Name == "RPG")
            //     .Include(g => g.Genre)
            //     .Include(g => g.DLCs)
            //     .ToList();
            
         return db.Games.Where(g => g.Genre.Name == "RPG").ToList();
            
            
            
        }

        public List<Game> GetGames(Specification<Game> specification) 
            => SpecificationQueryBuilder.GetQuery(db.Games, specification).ToList();
    }
}