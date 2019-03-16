using RobinHoodNet.Models;
using System.Threading.Tasks;

namespace RobinHoodNet.Interfaces
{
    public interface IRohinHoodClient
    {
        Task<(OAuthLoginRes LoginResponse, OAuthLoginMFARes MFAResponse)> Oauth2_Token_PostAsync<T>(T payload) where T : OAuthLoginReq;
        Task<UserRes> User_GetAsync();
    }
}
