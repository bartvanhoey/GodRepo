using DotNet8SpecificationPattern.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8SpecificationPattern.Specification;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
        Specification<TEntity> specification) where TEntity : BaseEntity
    {
        var query = inputQuery;
        if (specification?.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }
        
        if (specification?.Includes != null) 
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        
        if (specification?.OrderBy != null) 
            query = query.OrderBy(specification.OrderBy);
        
        if (specification?.OrderByDesc != null) 
            query = query.OrderByDescending(specification.OrderByDesc);

        return query;
    }
}