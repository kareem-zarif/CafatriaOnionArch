using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ItemNotes).HasMaxLength(256);


            builder.HasData(
                new OrderItem
                {
                    Id = Guid.Parse("c9999999-aaaa-aaaa-9999-99999999999c"),
                    OrderId = Guid.Parse("a9999999-aaaa-aaaa-9999-99999999999a"),
                    ProductId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), // Make sure this Product exists
                    Quantity = 2,
                    UnitPrice = 25.0,
                    ItemNotes = "No onions",
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                },
                new OrderItem
                {
                    Id = Guid.Parse("d9999999-aaaa-aaaa-9999-99999999999d"),
                    OrderId = Guid.Parse("b9999999-aaaa-aaaa-9999-99999999999b"),
                    ProductId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"), // Make sure this Product exists
                    Quantity = 3,
                    UnitPrice = 50.0,
                    ItemNotes = "Extra cheese",
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                }
            );
        }
    }
}
