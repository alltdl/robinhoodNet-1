using System;
using System.Net.Http;
using System.Threading.Tasks;
using RobinHoodNet.Interfaces;

namespace RobinHoodNet.Services
{
    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        public HttpClient()
        {
        }

        public Task<HttpResponseMessage> PostAsJsonAsync<T>(Uri requestUri, T value)
        {
            return this.httpClient.PostAsJsonAsync<T>(requestUri, value);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return this.httpClient.GetAsync(requestUri);
        }
    }
}
