using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.HasMany(order => order.Products)
                .WithMany(product => product.Orders)
                .UsingEntity<OrderItem>(
                    item => item.HasOne(orderItem => orderItem.Product)
                    .WithMany(product => product.OrderItems),

                    item => item.HasOne(orderItem => orderItem.Order)
                    .WithMany(order => order.OrderItems),

                    item =>
                    {
                        item.Property(orderItem => orderItem.Amount)
                            .HasDefaultValue(1);
                        item.HasKey(orderItem => orderItem.Id);
                        builder.Property(orderItem => orderItem.Id)
                            .IsRequired()
                            .HasColumnName("Id");
                    });
        }
    }
}
