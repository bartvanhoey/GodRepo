using DotNet8SpecificationPattern.Entities;

namespace DotNet8SpecificationPattern.Specification;

public class RpgGamesSpecification : Specification<Game>
{
    public RpgGamesSpecification() : base(g => g.Genre!.Name == "RPG")
    {
    }
}