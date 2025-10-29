using E_Commerce_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Domain.Contracts
{
    public interface IUintofwork
    {
        public IRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : Entity<Tkey>;

        public  Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
