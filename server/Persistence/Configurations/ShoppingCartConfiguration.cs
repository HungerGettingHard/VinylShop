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
                .HasForeignKey<Person>(person => person.ShoppingCartId)
                .IsRequired();

            builder.HasMany(cart => cart.Products)
                .WithMany(product => product.ShoppingCarts)
                .UsingEntity<ShoppingCartItem>(
                    item => item.HasOne(cartItem => cartItem.Product)
                    .WithMany(product => product.ShoppingCartItems),

                    item => item.HasOne(cartItem => cartItem.ShoppingCart)
                    .WithMany(cart => cart.ShoppingCartItems),

                    item =>
                    {
                        item.Property(cartItem => cartItem.Amount)
                            .HasDefaultValue(1);
                        item.HasKey(cartItem => cartItem.Id);
                        builder.Property(cartItem => cartItem.Id)
                            .IsRequired()
                            .HasColumnName("Id");
                    });
        }
    }
}
