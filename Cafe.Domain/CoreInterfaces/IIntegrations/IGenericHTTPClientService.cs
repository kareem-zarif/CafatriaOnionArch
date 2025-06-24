namespace Cafe.Domain.CoreInterfaces.IIntegrations
{
    //in core => as core have all abstractions of project (interfaces of services)
    //can be in application layer :: as Core and App Layer are the logic of business 
    public interface IGenericHTTPClientService
    {
        Task<R> GetAsync<R>(string url);
        Task<R> GetAllAsync<R>(string url);
        Task<R> PostAsync<Q, R>(string url, Q data);
        Task<R> PutAsync<Q, R>(string url, Q data);
        Task<R> DeleteAsync<R>(string url);
    }
}
