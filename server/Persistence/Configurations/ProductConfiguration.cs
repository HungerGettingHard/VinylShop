using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(product => product.Genres)
                .WithMany(genre => genre.Products);
        }
    }
}
