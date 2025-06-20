using Cafe.Domain;
using Cafe.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ManagerName).HasMaxLength(256);
            builder.Property(x => x.Address).HasMaxLength(256);

            builder.HasData(
                new Branch()
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Location = BranchLocationEnum.Zagazig,
                    ManagerName = "Alice",
                    OpenAt = new TimeOnly(8, 0),
                    CloseAt = new TimeOnly(18, 0),
                    Phone = "01212345678",
                    Address = "123 Main St",
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                },
                new Branch
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Location = BranchLocationEnum.Ismalia,
                    ManagerName = "Bob",
                    OpenAt = new TimeOnly(9, 0),
                    CloseAt = new TimeOnly(17, 0),
                    Phone = "01012345678",
                    Address = "456 Side St",
                    CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                    ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
                });
        }
    }
}
