using Cafe.Domain.CoreInterfaces.IIntegrations;

namespace Cafe.Infrastructure.Integrations.Integrations
{
    public class CafeHTTPClientService : GeneralHTTPClientService, ICafeHTTPClientService
    {
        public CafeHTTPClientService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
