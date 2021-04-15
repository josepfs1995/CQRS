using System.Threading.Tasks;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebAPI.Infra.Data{
    public class CQRSDbContext:DbContext, IUnitOfWork{
        public DbSet<Person> People { get; set; }
        public CQRSDbContext(DbContextOptions<CQRSDbContext> option):base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> Save()
        {
            return await this.SaveChangesAsync() > 0;
        }
    }
}