using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MenuName).HasMaxLength(128);

            builder.HasData(
               new Menu
               {
                   Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                   MenuName = "Breakfast",
                   CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                   ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
               },
               new Menu
               {
                   Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                   MenuName = "Lunch",
                   CreatedOn = new DateTime(2024, 6, 20, 10, 0, 0),
                   ModifiedOn = new DateTime(2024, 6, 20, 10, 0, 0)
               }
           );
        }
    }
}
