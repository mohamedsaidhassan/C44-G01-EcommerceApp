using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Domain.Contracts;
using E_Commerce_Domain.Entities.Basket;
using E_Commerce_Shared.DataTransferObjects.Basket;
using E_commerce_Presistance.Repositories;

namespace E_Commerce_Service.Services
{
    public class BasketService(IBasketRepo basketRepository,IMapper mapper) : IBasketService
    {
        public async Task<CustomerBasketDTO> CreateOrUpdateBasketAsync(CustomerBasketDTO basket, CancellationToken cancellationToken = default)
        {
            var mappedbasket = mapper.Map<CustomerBasket>(basket);
            var updatebasket = await basketRepository.CreateOrUpdateBasketAsync(mappedbasket);

            return mapper.Map<CustomerBasketDTO>(updatebasket);

        }

        public Task<bool> DeleteBasketAsync(string basketId, CancellationToken cancellationToken = default)
        {
            return basketRepository.DeleteBasketAsync(basketId);
        }

        public async Task<CustomerBasketDTO> GetBasketByIDAsync(string basketId, CancellationToken cancellationToken = default)
        {
            var basket =  await basketRepository.GetBasketByIDAsync(basketId);

            return  mapper.Map<CustomerBasketDTO>(basket);
        }
    }
}
