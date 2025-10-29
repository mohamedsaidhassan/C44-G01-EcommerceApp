using E_Commerce_Domain.Contracts;
using E_commerce_Presistance.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Service.Specifications
{
    public class BaseSpecifications<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }
     
        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
              
         }

        public ICollection<Expression<Func<TEntity, object>>> Includes { get; private set; }
        = new List<Expression<Func<TEntity, object>>>();

      public  Expression<Func<TEntity, object>> orderBy { get;  private set; }

        protected void AddorderBy(Expression<Func<TEntity, object>> Expression)
            => orderBy = Expression;

       

        public   Expression<Func<TEntity, object>> orderByDesc {get; private set; }

        protected void AddorderByDesc(Expression<Func<TEntity, object>> Expression)
          => orderByDesc = Expression;

        protected void AddInclude(Expression<Func<TEntity, object>> experssion)
        {
            Includes.Add(experssion);
        }

      public  int skip { get; private set;}
      public  int take { get; private set; }
      public  bool IsPaginated { get; private set; }

        //Expression<Func<TEntity, bool>> ISpecification<TEntity>.orderBy => throw new NotImplementedException();

        //Expression<Func<TEntity, bool>> ISpecification<TEntity>.orderByDesc => throw new NotImplementedException();

        protected void ApplyPagination(int pagesize, int pageindex)
        {
            IsPaginated = true;
            
            skip = pagesize * (pageindex - 1);

            take = pagesize;
        }

    }
}
