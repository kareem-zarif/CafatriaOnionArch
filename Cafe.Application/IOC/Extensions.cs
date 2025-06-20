using Cafe.Application.Services;
using Cafe.Application.Shared.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Application.IOC
{
    public static class Extensions
    {
        public static IServiceCollection ConfigAppAutoMapper(this IServiceCollection appServices)
        {
            appServices.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return appServices;
        }

        public static IServiceCollection ConfigAppServices(this IServiceCollection appServices)
        {
            //as your service depends on DbContext (which is itself registered as scoped). so use AddScoped with appServices
            appServices.AddScoped<IBranchAppService, BranchAppService>();

            return appServices;
        }
    }
}
