using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Extensions;

namespace CQRS.WebAPI.Infra.Repository{
    public class RedisRepository : IRedisRepository
    {
        private readonly IRedisContext _redisContext;
        public RedisRepository(IRedisContext redisContext)
        {
            _redisContext = redisContext;
        }
        public async Task Create<T>(string table, T model)
        {
            var response = await _redisContext.Get<ICollection<T>>(table);
            if(response == null) response = Activator.CreateInstance<List<T>>();
            response.Add(model);
            await _redisContext.Add(table, response);
        }
        public async Task CreateWithData<T>(string table, T model)
        {
            await _redisContext.Add(table, model);
        }

        public async Task<T> GetAll<T>(string table)
        {
            return await _redisContext.Get<T>(table);
        }
    }
}