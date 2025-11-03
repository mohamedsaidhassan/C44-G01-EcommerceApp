using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Shared.DataTransferObjects.Basket;

namespace E_Commerce_service_Abstraction.Service
{
    public interface IBasketService
    {
        Task<CustomerBasketDTO> GetBasketByIDAsync(string basketId, CancellationToken cancellationToken = default);
        Task<CustomerBasketDTO> CreateOrUpdateBasketAsync(CustomerBasketDTO basket, CancellationToken cancellationToken = default);
        Task<bool> DeleteBasketAsync(string basketId, CancellationToken cancellationToken = default);
    }
}
