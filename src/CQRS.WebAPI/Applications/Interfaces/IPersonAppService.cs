using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.WebAPI.Applications.ViewModels.Person;

namespace CQRS.WebAPI.Applications.Interfaces{
    public interface IPersonAppService{
        Task<bool> Create(CreatePersonViewModel model);
        Task<IEnumerable<GetPersonViewModel>> GetAll();
    }
}