using DotNet8SpecificationPattern.Data;
using DotNet8SpecificationPattern.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8SpecificationPattern.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
{
            _context = context;
        }

        public List<Game> GetAllGames()
        {
            return _context.Games
                .Where(g => g.Genre.Name == "RPG")
                .Include(g => g.Genre)
                .Include(g => g.DLCs)
                .ToList();
        }
    }
}