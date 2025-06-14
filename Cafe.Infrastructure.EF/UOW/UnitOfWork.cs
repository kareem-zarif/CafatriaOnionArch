using Cafe.Domain;
using Cafe.Domain.CoreInterfaces;
using Cafe.Domain.CoreInterfaces.IUOW;

namespace Cafe.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        //debency injection for context , all repos 
        private readonly CafeDBContext _context;
        private readonly IBaseRepo<Branch, Guid> _baseRepo;
        private readonly IBaseRepo<BranchSupplier, Guid> _branchSupplierRepo;
        private readonly IBaseRepo<Employee, Guid> _employeeRepo;
        private readonly IBaseRepo<Menu, Guid> _menuRepo;
        private readonly IBaseRepo<Order, Guid> _orderRepo;
        private readonly IBaseRepo<OrderItem, Guid> _orderItemRepo;
        private readonly IBaseRepo<Product, Guid> _productRepo;
        private readonly IBaseRepo<Supplier, Guid> _supplierRepo;
        private readonly IBaseRepo<Table, Guid> _tableRepo;
        public UnitOfWork(
            CafeDBContext context,
            IBaseRepo<Branch, Guid> baseRepo,
            IBaseRepo<BranchSupplier, Guid> branchSupplierRepo,
            IBaseRepo<Employee, Guid> employeeRepo,
            IBaseRepo<Menu, Guid> menuRepo,
            IBaseRepo<Order, Guid> orderRepo,
            IBaseRepo<OrderItem, Guid> orderItemRepo,
            IBaseRepo<Product, Guid> productRepo,
            IBaseRepo<Supplier, Guid> supplierRepo,
            IBaseRepo<Table, Guid> tableRepo
            )
        {
            _context = context;
            _baseRepo = baseRepo;
            _branchSupplierRepo = branchSupplierRepo;
            _employeeRepo = employeeRepo;
            _menuRepo = menuRepo;
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _productRepo = productRepo;
            _supplierRepo = supplierRepo;
            _tableRepo = tableRepo;
        }
        public IBaseRepo<Branch, Guid> BranchRepo => _baseRepo;

        public IBaseRepo<BranchSupplier, Guid> BranchSupplierRepo => _branchSupplierRepo;

        public IBaseRepo<Employee, Guid> EmployeeRepo => _employeeRepo;

        public IBaseRepo<Menu, Guid> MenuRepo => _menuRepo;

        public IBaseRepo<Order, Guid> OrderRepo => _orderRepo;

        public IBaseRepo<OrderItem, Guid> OrderItemRepo => _orderItemRepo;

        public IBaseRepo<Product, Guid> ProductRepo => _productRepo;

        public IBaseRepo<Supplier, Guid> SupplierRepo => _supplierRepo;

        public IBaseRepo<Table, Guid> TableRepo => _tableRepo;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
