using Cafe.Domain;
using Cafe.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.OrderedOn);

            builder.HasData(
                new Order
                {
                    Id = Guid.Parse("a9999999-aaaa-aaaa-9999-99999999999a"),
                    OrderStatus = OrderStatusEnum.Pending,
                    TotalMoney = 100.0,
                    OrderedOn = new DateTime(2024, 6, 20, 9, 0, 0),
                    TableId = Guid.Parse("11111111-aaaa-aaaa-aaaa-111111111111"),
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                },
                new Order
                {
                    Id = Guid.Parse("b9999999-aaaa-aaaa-9999-99999999999b"),
                    OrderStatus = OrderStatusEnum.Served,
                    TotalMoney = 150.0,
                    OrderedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    TableId = Guid.Parse("22222222-aaaa-aaaa-aaaa-222222222222"),
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                }
            );
        }
    }
}
