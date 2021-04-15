using System;

namespace CQRS.WebAPI.Applications.ViewModels.Person{
    public class GetPersonViewModel{
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}