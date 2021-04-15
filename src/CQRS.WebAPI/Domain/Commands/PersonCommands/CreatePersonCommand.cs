using System;
using MediatR;

namespace CQRS.WebAPI.Domain.Commads.PersonCommands{
    public class CreatePersonCommand:IRequest<bool>{
        public CreatePersonCommand(string firstName, string surname, DateTime birthdate)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            Surname = surname;
            Birthdate = birthdate;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}