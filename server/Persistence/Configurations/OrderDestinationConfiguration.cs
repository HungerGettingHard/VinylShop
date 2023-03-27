using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderDestinationConfiguration : IEntityTypeConfiguration<OrderDestination>
    {
        public void Configure(EntityTypeBuilder<OrderDestination> builder)
        {
            builder.HasKey(destination => destination.Id);
            builder.Property(destination => destination.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(destination => destination.Name)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}
