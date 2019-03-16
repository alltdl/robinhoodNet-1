using RobinHoodNet.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class HttpClientFake : IHttpClient
    {
        public Func<Uri, object, Task<HttpResponseMessage>> PostAsJsonAsyncCallback;
        public Task<HttpResponseMessage> PostAsJsonAsync<T>(Uri requestUri, T value)
        { 
            return PostAsJsonAsyncCallback.Invoke(requestUri, value);
        }
    }
}
