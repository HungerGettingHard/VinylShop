using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(person => person.Id);
            builder.Property(person => person.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(person => person.Name)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(person => person.Login)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(person => person.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(person => person.ShoppingCart)
                .WithOne(cart => cart.Person)
                .IsRequired();
        }
    }
}
