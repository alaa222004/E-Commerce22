

namespace E_Commerce.Persistence.Repositories
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> inputQuery
            , ISpecification<TEntity> specification) 
            where TEntity : class
        {
            var query = inputQuery;
          

            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if(specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }   
            else if(specification.OrderByDesc != null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }
            if (specification.IsPaginated)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            //query =specification.Includes.Aggregate(query,
            //    (query, include) => query.Include(include));
            return query;
        }
    }
}
