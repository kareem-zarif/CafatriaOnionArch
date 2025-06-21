using Cafe.Domain;
using Cafe.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.HasIndex(x => x.Email);

            builder.HasData(
               new Employee
               {
                   Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                   Name = "John Doe",
                   Phone = "john.doe@example.com",
                   Email = "john.doe@example.com",
                   Role = EmpRole.Casher,
                   IsActive = true,
                   HireDate = new DateOnly(2022, 1, 10),
                   BranchId = Guid.Parse("11111111-1111-1111-1111-111111111111")
               },
               new Employee
               {
                   Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                   Name = "Jane Smith",
                   Phone = "jane.smith@example.com",
                   Email = "jane.smith@example.com",
                   Role = EmpRole.ServiceEmp,
                   IsActive = true,
                   HireDate = new DateOnly(2023, 2, 15),
                   BranchId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                   CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                   ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
               });
        }
    }
}
