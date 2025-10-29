global using E_Commerce_Domain.Entities;
using E_Commerce_Domain.Contracts;
using E_commerce_Presistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;




namespace E_commerce_Presistance.Repositories
{
    internal class Repository<TEntity,Tkey>(ApplicationContext dbcontext) : IRepository<TEntity,Tkey> where TEntity : Entity<Tkey>
    {
        public void Add(TEntity entity)=> dbcontext.Set<TEntity>().Add(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
          return await dbcontext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity> includes, CancellationToken cancellationToken = default)
        {
            return await dbcontext.Set<TEntity>().GetSpecQuery<TEntity>(includes).FirstOrDefaultAsync(cancellationToken);
        }

        public void Remove(TEntity entity)=> dbcontext.Set<TEntity>().Remove(entity);
        

        public void Update(TEntity entity) => dbcontext.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> includes,CancellationToken cancellationToken = default)
        {
            return await dbcontext.Set<TEntity>().GetSpecQuery<TEntity>(includes).ToListAsync(cancellationToken);
        }

    }
}
