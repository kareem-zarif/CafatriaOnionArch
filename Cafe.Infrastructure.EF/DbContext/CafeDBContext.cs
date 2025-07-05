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

        public virtual DbSet<Branch> Branches { get; set; }
        //virtiual for unit testing and mocking and any extensibility and testability
        //	Writing automated tests 
        //  Using lazy loading to improve performance 
        //  Creating derived contexts for different environments (test/production)
        public virtual DbSet<BranchSupplier> BranchesSupplier { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
    }
}
