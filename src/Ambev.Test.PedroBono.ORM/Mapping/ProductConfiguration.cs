using Ambev.Test.PedroBono.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Test.PedroBono.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            // Configure the Price property
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Category)
                .HasMaxLength(100);

            builder.Property(p => p.Image)
                .IsRequired(false);

            builder.Property(p => p.Rate)
                .HasColumnType("decimal(3,2)")
                .HasDefaultValue(0);

            builder.Property(p => p.Count)
                .HasDefaultValue(0); 
            
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); 
           
            builder.Property(p => p.UpdatedAt)
                .IsRequired(false)
                .HasDefaultValue(null);
        }
    }
}
