using E_Commerce_Domain.Entities;
using E_Commerce_Domain.Entities.Products;
using E_commerce_Presistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce_Domain.Contracts
{
    public interface IRepository<TEntity,TKey> where TEntity : Entity<TKey>
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        public Task<TEntity?> GetByIdAsync(ISpecification<TEntity> includes, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken=default);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> includes, CancellationToken cancellationToken = default);
    }
}
