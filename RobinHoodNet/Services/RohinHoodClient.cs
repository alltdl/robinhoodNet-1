using RobinHoodNet.Interfaces;
using RobinHoodNet.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobinHoodNet.Services
{
    public class RohinHoodClient : IRohinHoodClient
    {
        private readonly IHttpClient httpClient;

        private OAuthLoginRes oAuthLoginRes = null;

        public RohinHoodClient(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<(OAuthLoginRes LoginResponse, OAuthLoginMFARes MFAResponse)> Oauth2_Token_PostAsync<T>(T payload) where T : OAuthLoginReq
        {
            var res = await this.httpClient.PostAsJsonAsync(Endpoints.Oauth2_Token_Post, payload);
            res.EnsureSuccessStatusCode();
            var response = await res.Content.ReadAsStringAsync();

            OAuthLoginMFARes mfares = null;
            if (response.Contains(nameof(OAuthLoginMFARes.mfa_required)))
            {
                mfares = Newtonsoft.Json.JsonConvert.DeserializeObject<OAuthLoginMFARes>(response);
            }
            else
            {
                oAuthLoginRes = Newtonsoft.Json.JsonConvert.DeserializeObject<OAuthLoginRes>(response);
            }
            return (oAuthLoginRes, mfares);
        }

        public async Task<UserRes> User_GetAsync()
        {
            var res = await this.httpClient.GetAsync(Endpoints.User_Get);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsAsync<UserRes>();
        }
    }
}
