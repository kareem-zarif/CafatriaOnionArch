using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class BranchSupplierConfig : IEntityTypeConfiguration<BranchSupplier>
    {
        public void Configure(EntityTypeBuilder<BranchSupplier> builder)
        {
            builder.HasKey(x => new { x.BranchId, x.SupplierId });
            builder.Property(x => x.HistoryOfDeal).HasMaxLength(50);

            builder.HasData(
                new BranchSupplier
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    BranchId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    SupplierId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    LastDeal = new DateTime(2024, 1, 1),
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                }
            );
        }
    }
}
