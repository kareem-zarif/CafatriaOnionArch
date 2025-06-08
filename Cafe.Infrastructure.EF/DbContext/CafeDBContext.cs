using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cafe.Infrastructure.EF
{
    public class CafeDBContext : DbContext
    {
        //onconfiguring :: Separated to IOC.Extensions.cs 
        //      0-Can use it If not Have original code , has only IL code
        //      1-Modular Configuration ::Easy to modify or replace // test
        //      2-Single Responsibility Principle
        //      3-Dependency Inversion :: to use UOW without needing know config details
        //      4-Centralized Registration :: All EF-related repos in one place
        public CafeDBContext(DbContextOptions<CafeDBContext> configOptions) : base(configOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchSupplier> BranchesSupplier { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
