using Cafe.Domain.CoreInterfaces.IIntegrations;
using System.Net;
using System.Net.Http.Json;

namespace Cafe.Infrastructure.Integrations.Integrations
{
    //in infra as i not need app layer logic , as MVC or any presentation layer or any external api will call my application , has its validation Dtos
    // Core = interface,
    // Infra = implementation,
    // App = business logic,
    // API/Presentation = validation and DTOs.
    public class GeneralHTTPClientService : IGenericHTTPClientService
    {
        private readonly HttpClient _httpClient;//to send request and receive response via url
        public GeneralHTTPClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<R> GetAsync<R>(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            try
            {
                var response = await _httpClient.GetAsync(url); //send GET Request and return Response
                response.EnsureSuccessStatusCode();//throw exception if failed get HTTPResponse
                var result = await response.Content.ReadFromJsonAsync<R>();//transfer the response body from json to object R
                return result!; //! null-forgiving operator , tell compiler i know it can be null and remove the warning , and know it may throw runtime exception if not handled 
            }
            catch (Exception ex)
            {
                throw; //to save it in stack trace to send this exception as same exception to MVC Controller
            }
        }
        public async Task<R> GetAllAsync<R>(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            try
            {
                var respose = await _httpClient.GetAsync(url);

                if (respose.StatusCode == HttpStatusCode.NotFound)
                    throw new Exception($"The requested resource was not found: {url}");

                respose.EnsureSuccessStatusCode();
                var result = await respose.Content.ReadFromJsonAsync<R>();
                return result;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<R> PostAsync<Q, R>(string url, Q data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<R>();
                return result;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<R> PutAsync<Q, R>(string url, Q data)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, data);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<R>();
                return result;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<R> DeleteAsync<R>(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<R>();
                return result;
            }
            catch (Exception ex) { throw; }
        }
    }
}
