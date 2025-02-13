using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ambev.Test.PedroBono.Domain.Entities;

namespace Ambev.Test.PedroBono.ORM.Mapping
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.ToTable("CartProducts");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasOne(x => x.Cart)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.CartId)
                .IsRequired();

            builder.Property(u => u.Qty).IsRequired();
        }
    }
}
