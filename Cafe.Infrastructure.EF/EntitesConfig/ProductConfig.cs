using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.EF
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(256);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => new { x.IsAvailable, x.Category });

            builder.HasData(
              new Product
              {
                  Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                  Name = "Burger",
                  Price = 25.0,
                  MenuId = Guid.Parse("88888888-8888-8888-8888-888888888888")
              },
              new Product
              {
                  Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                  Name = "Pizza",
                  Price = 50.0,
                  MenuId = Guid.Parse("88888888-8888-8888-8888-888888888888")
              }
          );
        }
    }
}
