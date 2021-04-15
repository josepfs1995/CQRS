using System.Collections.Immutable;
using CQRS.WebAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.WebAPI.Infra.Mappings{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.FirstName)
            .HasColumnType("Varchar(50)");

             builder.Property(x=>x.Surname)
            .HasColumnType("Varchar(50)");
        }
    }
}