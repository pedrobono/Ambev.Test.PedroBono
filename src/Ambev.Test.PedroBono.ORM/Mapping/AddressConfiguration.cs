using Ambev.Test.PedroBono.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.Test.PedroBono.ORM.Mapping
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.HasOne<User>(x => x.User)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.UserId)
                .IsRequired();

            builder.Property(u => u.City).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Street).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Number).IsRequired();
            builder.Property(u => u.Zipcode).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Lat).HasMaxLength(13);
            builder.Property(u => u.Long).HasMaxLength(13);

        }
    }
}
