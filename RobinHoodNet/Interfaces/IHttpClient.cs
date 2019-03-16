using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobinHoodNet.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> PostAsJsonAsync<T>(Uri requestUri, T value);
        Task<HttpResponseMessage> GetAsync(Uri requestUri);
    }
}
