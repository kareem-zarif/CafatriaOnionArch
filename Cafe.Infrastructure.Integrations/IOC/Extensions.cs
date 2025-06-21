using Cafe.Domain.CoreInterfaces.IIntegrations;
using Cafe.Infrastructure.Integrations.Integrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Infrastructure.Integrations.IOC
{
    public static class Extensions
    {
        public static IServiceCollection ConfigIntegration(this IServiceCollection services, IConfiguration config)
        {

            services.AddHttpClient<CafeHTTPClientService>(client =>
            {
                //client.BaseAddress = new Uri(config["HTTPClientSettings:BaseUrl"]);

                //client.Timeout = TimeSpan.FromSeconds(int.Parse(config["HTTPClientSettings:TimeoutSeconds"])); //allows you to change the timeout without recompiling your code and can change it thorow settings file with dll when production
            });

            services.AddScoped<IGenericHTTPClientService, GeneralHTTPClientService>();
            services.AddScoped<ICafeHTTPClientService, CafeHTTPClientService>();


            return services;
        }
    }
}
