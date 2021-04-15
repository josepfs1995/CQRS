using System.Threading;
using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Commads.PersonCommands;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Domain.Model;
using Mapster;
using MediatR;

namespace CQRS.WebAPI.Infra.Commands{
    public class PersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        public PersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = request.Adapt<Person>();
            _personRepository.Create(person);
            return await _personRepository.UoW.Save();
        }
    }
}