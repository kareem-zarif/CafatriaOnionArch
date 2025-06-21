using Cafe.Domain;
using Cafe.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class TableConfig : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TableName).IsRequired().HasMaxLength(46);

            builder.HasIndex(x => x.TableStatus);

            builder.HasData(
               new Table
               {
                   Id = Guid.Parse("11111111-aaaa-aaaa-aaaa-111111111111"),
                   TableName = "Table 1",
                   Capacity = 4,
                   TableStatus = TableStatusEnum.Available
               },
               new Table
               {
                   Id = Guid.Parse("22222222-aaaa-aaaa-aaaa-222222222222"),
                   TableName = "Table 2",
                   Capacity = 6,
                   TableStatus = TableStatusEnum.Occupied
               }
           );
        }
    }
}
