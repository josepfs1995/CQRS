using MediatR;

namespace CQRS.WebAPI.Domain.Events.RedisEvents{
    public class CreateRedisEvent<T>:INotification{
        public CreateRedisEvent(string table, T data)
        {
            Table = table;
            Data = data;
        }
        public string Table { get; set; }
        public T Data { get; set; }
    }
}