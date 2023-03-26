using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(cart => cart.Id);
            builder.Property(cart => cart.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.HasOne(cart => cart.Person)
                .WithOne(person => person.ShoppingCart)
                .HasForeignKey<Person>(person => person.ShoppingCartId);

            builder.HasMany(cart => cart.ShoppingCartItems)
                .WithOne(cartItem => cartItem.ShoppingCart);
        }
    }
}
