using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    internal class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Address).HasMaxLength(265);

            builder.Property(x => x.Address);

            builder.HasData(
               new Supplier
               {
                   Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                   Name = "Fresh Foods Co.",
                   phone = "01234567890",
                   Address = "789 Supplier Ave",
                   CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                   ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
               },
               new Supplier
               {
                   Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                   Name = "Quality Supplies Ltd.",
                   phone = "01123456789",
                   Address = "1010 Market St",
                   CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                   ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
               }
           );
        }
    }
}
