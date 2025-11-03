using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using E_Commerce_service_Abstraction.Service;
using StackExchange.Redis;

namespace E_commerce_Presistance.Services
{
    public class CashService(IConnectionMultiplexer multiplexer) : ICashService
    {
        private readonly IDatabase _database = multiplexer.GetDatabase();
        public async Task<string?> GetAsync(string key)
        {
            return await _database.StringGetAsync(key);
           
        }

        public async Task SetAsync(string key, string value, TimeSpan TTL)
        {
            var json = JsonSerializer.Serialize(value);
                await _database.StringSetAsync(key,json,TTL);
        }
    }
}
