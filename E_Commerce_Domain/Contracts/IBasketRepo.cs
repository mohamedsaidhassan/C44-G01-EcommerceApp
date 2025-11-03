using E_Commerce_Domain.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Domain.Contracts
{
    public interface IBasketRepo
    {
        Task<bool> DeleteBasketAsync(string id);

        Task<CustomerBasket?> GetBasketByIDAsync(string id);

        Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket basket,TimeSpan? TTl=null);
    }
}
