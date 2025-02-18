using Ambev.Test.PedroBono.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Test.PedroBono.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Date)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(s => s.CustomerId)
                .IsRequired();

            builder.HasOne(s => s.Customer)
                .WithMany(u => u.SalesAsCustomer)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.UserId)
                .IsRequired();

            builder.HasOne(s => s.User)
                .WithMany(u => u.SalesAsCreator)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<int>();
        }
    }
}
