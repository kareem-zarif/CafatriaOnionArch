using Cafe.Application.Services;
using Cafe.Application.Shared.IServices;


namespace Cafe.UI.WEB.MVC2.IOC
{
    public static class Extensions
    {
        public static IServiceCollection ConfigMVC(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IBranchAppService, BranchAppService>();
            return services;
        }
    }
}
