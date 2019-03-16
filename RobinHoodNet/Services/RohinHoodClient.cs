using RobinHoodNet.Interfaces;
using RobinHoodNet.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobinHoodNet.Services
{
    public class RohinHoodClient : IRohinHoodClient
    {
        private readonly HttpClient httpClient;
        public RohinHoodClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<(OAuthLoginRes, OAuthLoginMFARes)> Oauth2_Token_PostAsync<T>(T payload) where T : OAuthLoginReq
        {
            var res = await this.httpClient.PostAsJsonAsync(Endpoints.Oauth2_Token_Post, payload);
            res.EnsureSuccessStatusCode();
            var response = await res.Content.ReadAsStringAsync();
            var mfares = Newtonsoft.Json.JsonConvert.DeserializeObject<OAuthLoginMFARes>(response);
            var loginres = Newtonsoft.Json.JsonConvert.DeserializeObject<OAuthLoginRes>(response);
            return (loginres, mfares);
        }
    }
}
