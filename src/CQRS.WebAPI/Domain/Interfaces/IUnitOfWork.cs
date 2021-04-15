using System.Threading.Tasks;
namespace CQRS.WebAPI.Domain.Interfaces{
    public interface IUnitOfWork{
        Task<bool> Save();
    }
}