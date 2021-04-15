using System.Threading;
using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Commads.PersonCommands;
using CQRS.WebAPI.Domain.Events.RedisEvents;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Domain.Model;
using Mapster;

namespace CQRS.WebAPI.Infra.Events{
    public class RedisEventHandler : MediatR.INotificationHandler<CreateRedisEvent<CreatePersonCommand>>
    {
        private readonly IRedisRepository _redisRepository;
        public RedisEventHandler(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }
        public async Task Handle(CreateRedisEvent<CreatePersonCommand> notification, CancellationToken cancellationToken)
        {
            var person = notification.Data.Adapt<Person>();
            await _redisRepository.Create("People", person);
        }
    }
}