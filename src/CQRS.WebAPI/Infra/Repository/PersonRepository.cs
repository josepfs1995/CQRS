using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Domain.Model;
using CQRS.WebAPI.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebAPI.Infra.Repository{
    public class PersonRepository : IPersonRepository
    {
        private readonly CQRSDbContext _context;
        public PersonRepository(CQRSDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UoW => _context;
        public void Create(Person model)
        {
            _context.Add(model);
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
           return await _context.People.ToListAsync();
        }
    }
}