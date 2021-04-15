using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Domain.Model;
using CQRS.WebAPI.Domain.Queries.PersonQueries;
using MediatR;

namespace CQRS.WebAPI.Infra.Commands{
    public class PersonQueryHandler : IRequestHandler<PersonQuery, IEnumerable<Person>>
    {
        private readonly IRedisRepository _redisRepository;
        private readonly IPersonRepository _personRepository;
        public PersonQueryHandler(IPersonRepository personRepository, IRedisRepository redisRepository)
        {
            _personRepository = personRepository;
            _redisRepository = redisRepository;
        }
        public async Task<IEnumerable<Person>> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            var response  = await _redisRepository.GetAll<IEnumerable<Person>>("People");
            if(response == null){
                response = await _personRepository.GetAll();
                await _redisRepository.CreateWithData("People", response);
            }
            return response;
        }
    }
}