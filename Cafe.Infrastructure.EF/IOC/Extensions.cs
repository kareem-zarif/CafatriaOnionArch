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

            return services;
        }
    }
}
