using System.Collections.Generic;
using CQRS.WebAPI.Domain.Model;
using MediatR;

namespace CQRS.WebAPI.Domain.Queries.PersonQueries{
    public class PersonQuery:IRequest<IEnumerable<Person>>{
       
    }
}