using System;
namespace CQRS.WebAPI.Domain.Model{
    public class Person{
        public Guid Id { get; set; }    
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}