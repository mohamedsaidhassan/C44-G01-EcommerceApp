using E_Commerce_Domain.Contracts;
using E_commerce_Presistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Presistance.Repositories
{
    public class Uintofwork(ApplicationContext dbcontext) : IUintofwork
    {
        private readonly Dictionary<string, object> _rebositories = [];
        public IRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : Entity<Tkey>
        {
                var typeName = typeof(TEntity).Name;

                if (_rebositories.TryGetValue(typeName, out object? value))
                    return (value as IRepository<TEntity, Tkey>)!;

                var repo = new Repository<TEntity,Tkey>(dbcontext);

                _rebositories.Add(typeof(TEntity).Name, repo);
                return repo;
        }

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
            => dbcontext.SaveChangesAsync(cancellationToken);
   
    }
}
