using Cafe.Domain;
using Cafe.Domain.CoreInterfaces;
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

            //AddTransient for repos:
            //  1-Thread Safety: Each request gets its own repository instance
            //  2-No State Sharing:Each transaction(UOW) starts fresh and Prevents data leaks between requests
            // 3-Proper garbage collection

            //❌ Singleton: Creates one instance shared across the entire application ex:AppSettings
            //❌ Scoped: Creates one instance per scope (e.g., per HTTP request in a web app).ex: DbContext =>updates a user’s profile and logs the action; both use the same DbContext for consistency but every request use differnr dbcontext instance

            services.AddTransient<IBaseRepo<Branch, Guid>, BaseRepo<Branch, Guid>>();
            services.AddTransient<IBaseRepo<BranchSupplier, Guid>, BaseRepo<BranchSupplier, Guid>>();
            services.AddTransient<IBaseRepo<Employee, Guid>, BaseRepo<Employee, Guid>>();
            services.AddTransient<IBaseRepo<Menu, Guid>, BaseRepo<Menu, Guid>>();
            services.AddTransient<IBaseRepo<Order, Guid>, BaseRepo<Order, Guid>>();
            services.AddTransient<IBaseRepo<OrderItem, Guid>, BaseRepo<OrderItem, Guid>>();
            services.AddTransient<IBaseRepo<Product, Guid>, BaseRepo<Product, Guid>>();
            services.AddTransient<IBaseRepo<Supplier, Guid>, BaseRepo<Supplier, Guid>>();
            services.AddTransient<IBaseRepo<Table, Guid>, BaseRepo<Table, Guid>>();

            return services;
        }
    }
}
