using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using E_Commerce_Domain.Entities;

namespace E_commerce_Presistance.Repositories
{
    public interface ISpecification<TEntinty> 
    {
        public Expression<Func<TEntinty, bool>>? Criteria { get; }

        public Expression<Func<TEntinty, object>> orderBy { get; }

        public Expression<Func<TEntinty, object>> orderByDesc { get; }
        public ICollection<Expression<Func<TEntinty,object>>> Includes { get;  }

        int skip { get; }
        int take { get; }
        bool IsPaginated { get; }

    }
}
