using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.WebAPI.Applications.Interfaces;
using CQRS.WebAPI.Applications.ViewModels.Person;
using CQRS.WebAPI.Domain.Commads.PersonCommands;
using CQRS.WebAPI.Domain.Events.RedisEvents;
using CQRS.WebAPI.Domain.Queries.PersonQueries;
using Mapster;
using MediatR;

namespace CQRS.WebAPI.Applications.Services{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMediator _mediator;
        public PersonAppService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<bool> Create(CreatePersonViewModel model)
        {
            var personCommand = new CreatePersonCommand(model.FirstName, model.Surname, model.Birthdate);
            var response = await _mediator.Send(personCommand);
            if(response){
                var redisEvent = new CreateRedisEvent<CreatePersonCommand>("People", personCommand);
                await _mediator.Publish(redisEvent);
            }
            return response;
        }
        public async Task<IEnumerable<GetPersonViewModel>> GetAll()
        {
            var personQuery = new PersonQuery();
            var response = await _mediator.Send(personQuery);
            return response.Adapt<IEnumerable<GetPersonViewModel>>();
        }
    }
}