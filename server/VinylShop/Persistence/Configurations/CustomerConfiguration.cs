using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(genre => genre.Id);
            builder.Property(genre => genre.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(genre => genre.Name)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}
