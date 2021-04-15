
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Model;

namespace CQRS.WebAPI.Domain.Interfaces
{
    public interface IPersonRepository{
        Task<IEnumerable<Person>> GetAll();
        void Create(Person model);
        public IUnitOfWork UoW { get; }
    }
}