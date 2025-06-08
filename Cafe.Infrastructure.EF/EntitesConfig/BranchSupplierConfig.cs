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
        }
    }
}
