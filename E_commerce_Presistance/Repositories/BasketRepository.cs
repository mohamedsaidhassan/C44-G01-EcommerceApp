using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using E_Commerce_Domain.Contracts;
using E_Commerce_Domain.Entities.Basket;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;

namespace E_commerce_Presistance.Repositories
{
    public class BasketRepository(IConnectionMultiplexer multiplexer) : IBasketRepo
    {
        private readonly StackExchange.Redis.IDatabase _database = multiplexer.GetDatabase();
        public async Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TTl = null)
        {
            var json = JsonSerializer.Serialize(basket);

            await _database.StringSetAsync(basket.Id,json, TTl ?? TimeSpan.FromDays(7));

            return (await GetBasketByIDAsync(basket.Id))!;
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return  await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetBasketByIDAsync(string id)
        {

            var json= await _database.StringGetAsync(id);
            if(json.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(json);
                
        }
    }
}
