using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Model;

namespace CQRS.WebAPI.Domain.Interfaces
{
    public interface IRedisRepository{
        Task<T> GetAll<T>(string table);
        Task Create<T>(string table, T model);
        Task CreateWithData<T>(string table, T model);
    }
}