using Cafe.Domain;
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
        }
    }
}
