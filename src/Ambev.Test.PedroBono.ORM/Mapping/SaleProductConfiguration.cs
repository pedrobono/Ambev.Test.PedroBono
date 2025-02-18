using Ambev.Test.PedroBono.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Test.PedroBono.ORM.Mapping
{
    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.ToTable("SaleProducts");

            builder.HasKey(sp => sp.Id);
            builder.Property(sp => sp.Id).ValueGeneratedOnAdd();

            builder.Property(sp => sp.SaleId)
                .IsRequired();

            builder.Property(sp => sp.ProductId)
                .IsRequired();

            builder.Property(sp => sp.Discount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(sp => sp.Qty)
                .IsRequired();

            builder.Property(sp => sp.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sp => sp.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sp => sp.Status)
                .IsRequired();

            builder.HasOne(sp => sp.Sale)
                .WithMany(s => s.Products)
                .HasForeignKey(sp => sp.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sp => sp.Product)
                .WithMany()
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
