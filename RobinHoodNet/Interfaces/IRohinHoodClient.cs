using RobinHoodNet.Models;
using System.Threading.Tasks;

namespace RobinHoodNet.Interfaces
{
    public interface IRohinHoodClient
    {
        Task<(OAuthLoginRes, OAuthLoginMFARes)> Oauth2_Token_PostAsync<T>(T payload) where T : OAuthLoginReq;
    }
}
