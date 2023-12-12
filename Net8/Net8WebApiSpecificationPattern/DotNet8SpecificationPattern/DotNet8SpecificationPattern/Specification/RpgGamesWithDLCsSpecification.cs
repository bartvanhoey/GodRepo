using DotNet8SpecificationPattern.Entities;

namespace DotNet8SpecificationPattern.Specification;

public class RpgGamesWithDlCsSpecification : Specification<Game>
{
    public RpgGamesWithDlCsSpecification() : base(g => g.Genre!.Name == "RPG")
    {
        AddInclude(g => g.Genre!);
        AddInclude(g => g.DLCs);
        AddOrderBy(g => g.Name);
    }
}