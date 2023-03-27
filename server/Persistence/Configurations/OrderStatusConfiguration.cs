using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(status => status.Id);
            builder.Property(status => status.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(status => status.Name)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}
