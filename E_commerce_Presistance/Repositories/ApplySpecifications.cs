using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Presistance.Repositories
{
    internal static class ApplySpecifications
    {
        

        public static IQueryable<TEntity> GetSpecQuery<TEntity>(this IQueryable<TEntity> inputquery,ISpecification<TEntity> spec) where TEntity : class
        {
           
            var query = inputquery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
           


            if(spec.orderBy != null)
            {
                query = query.OrderBy(spec.orderBy);
            }
            else if(spec.orderByDesc != null)
            {
                query = query.OrderByDescending(spec.orderByDesc);
            }

            if(spec.IsPaginated)
            {
                query = query.Skip(spec.skip).Take(spec.take);
            }

            return query;
        }


    }
}
