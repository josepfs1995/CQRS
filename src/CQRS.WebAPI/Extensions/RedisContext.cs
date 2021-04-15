using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CQRS.WebAPI.Extensions{
    public interface IRedisContext{
        Task Add<T>(string key, T data);
        Task<T> Get<T>(string key);
        Task Remove(string key);
    }
    public class RedisContext : IRedisContext
    { 
        private readonly IDistributedCache _distributedCache;
        public RedisContext(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task Add<T>(string key, T data)
        {
            if(data == null) throw new ArgumentNullException("The value is null");
            string json = JsonSerializer.Serialize(data);
            await _distributedCache.SetStringAsync(key, json, new DistributedCacheEntryOptions{
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });
        }
        public async Task<T> Get<T>(string key)
        {
            string json = await _distributedCache.GetStringAsync(key);
            if(string.IsNullOrEmpty(json)) return default(T);
            return JsonSerializer.Deserialize<T>(json);
        }
        public async Task Remove(string key)
        {
           await _distributedCache.RemoveAsync(key);
        }
    }
}