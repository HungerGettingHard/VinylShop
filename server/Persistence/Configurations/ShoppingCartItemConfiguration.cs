using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasKey(cartItem => cartItem.Id);
            builder.Property(cartItem => cartItem.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(cartItem => cartItem.Amount)
                .IsRequired();

            builder.HasOne(cartItem => cartItem.ShoppingCart)
                .WithMany(cart => cart.ShoppingCartItems);

            builder.HasOne(cartItem => cartItem.Product)
                .WithMany(product => product.ShoppingCartItems);
        }
    }
}
