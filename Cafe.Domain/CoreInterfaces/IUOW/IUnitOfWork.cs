namespace Cafe.Domain.CoreInterfaces.IUOW
{
    //benefits of UOW
    //-Use Dbcontext once so can change it , maintain it , test it without application layer(EntityManagment or Controllers  ) feels
    //-Reduces database round trips (all changes happen in memory and commited once to database)
    //-All operations succeed or fail together (same as transiction) ==Prevents partial updates
    //-Proper disposal of DbContext and free connection with database
    //-Facilitates unit testing
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepo<Branch, Guid> BranchRepo { get; }
        //unitOfWork.CategoryRepository = new CategoryRepository(); // Won't compile! becauese of no set accessor in property
        IBaseRepo<BranchSupplier, Guid> BranchSupplierRepo { get; }
        IBaseRepo<Employee, Guid> EmployeeRepo { get; }
        IBaseRepo<Menu, Guid> MenuRepo { get; }
        IBaseRepo<Order, Guid> OrderRepo { get; }
        IBaseRepo<OrderItem, Guid> OrderItemRepo { get; }
        IBaseRepo<Product, Guid> ProductRepo { get; }
        IBaseRepo<Supplier, Guid> SupplierRepo { get; }
        IBaseRepo<Table, Guid> TableRepo { get; }

        Task<int> Complete();

    }
}
