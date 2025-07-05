using Cafe.Domain.CoreInterfaces;
using Cafe.Domain.CoreInterfaces.IUOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Infrastructure.EF
{
    public static class Extensions
    {
        //IConfiguration access Settings file in API Layer
        public static IServiceCollection ConfigEF(this IServiceCollection services, IConfiguration cafeDbcontextConfig)
        {
            //get connectionString from Settings.file in API Layer
            var connString = cafeDbcontextConfig.GetConnectionString("CafeConn");

            services.AddDbContext<CafeDBContext>(options =>
            {
                #region moreOptions
                //options.UseSqlServer(connString, sqlOpts =>
                //{
                //    sqlOpts.EnableRetryOnFailure(
                //        maxRetryCount: 3,
                //        maxRetryDelay: TimeSpan.FromSeconds(5),
                //        errorNumbersToAdd: null);
                //});
                #endregion
                options.UseSqlServer(connString);
            });


            services.AddScoped(typeof(IBaseRepo<,>), typeof(BaseRepo<,>));
            //services.AddTransient<IBaseRepo<Branch, Guid>, BaseRepo<Branch, Guid>>();
            //services.AddTransient<IBaseRepo<BranchSupplier, Guid>, BaseRepo<BranchSupplier, Guid>>();
            //services.AddTransient<IBaseRepo<Employee, Guid>, BaseRepo<Employee, Guid>>();
            //services.AddTransient<IBaseRepo<Menu, Guid>, BaseRepo<Menu, Guid>>();
            //services.AddTransient<IBaseRepo<Order, Guid>, BaseRepo<Order, Guid>>();
            //services.AddTransient<IBaseRepo<OrderItem, Guid>, BaseRepo<OrderItem, Guid>>();
            //services.AddTransient<IBaseRepo<Product, Guid>, BaseRepo<Product, Guid>>();
            //services.AddTransient<IBaseRepo<Supplier, Guid>, BaseRepo<Supplier, Guid>>();
            //services.AddTransient<IBaseRepo<Table, Guid>, BaseRepo<Table, Guid>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
