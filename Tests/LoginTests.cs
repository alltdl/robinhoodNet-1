using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobinHoodNet.Models;
using RobinHoodNet.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class LoginTests
    {
        private HttpClientFake HttpClientFake;
        private RohinHoodClient RohinHoodClient;
        [TestInitialize]
        public void Init()
        {
            HttpClientFake = new HttpClientFake();
            RohinHoodClient = new RohinHoodClient(HttpClientFake);
        }


        [TestMethod]
        public void TestLoginBadRequest()
        {
            try
            {
                HttpClientFake.PostAsJsonAsyncCallback = (u, r) =>
                {
                    return Task.FromResult(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
                };
                var req = new OAuthLoginReq { };
                var res = RohinHoodClient.Oauth2_Token_PostAsync(req).Result;

            }
            catch (System.AggregateException e)
            {
                Assert.IsInstanceOfType(e.InnerException, typeof(System.Net.Http.HttpRequestException));
            }
        }

        [TestMethod]
        public void TestLoginWithoutMFA()
        {
            var serverresponse = new OAuthLoginRes { access_token = "somerandomaccesscode", backup_code = null, expires_in = 86400, mfa_code = "12345", refresh_token = "refreshtoken", token_type = "Bearer", scope = "internal" };
            HttpClientFake.PostAsJsonAsyncCallback = (u, r) =>
            {
                var msg = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
                msg.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(serverresponse), System.Text.Encoding.UTF8, "application/json");
                return Task.FromResult(msg);
            };
            var req = new OAuthLoginReq { };
            var res = RohinHoodClient.Oauth2_Token_PostAsync(req).Result;
            Assert.IsNull(res.MFAResponse);
            Assert.IsNotNull(res.LoginResponse);
            Assert.AreEqual(res.LoginResponse.access_token, serverresponse.access_token);
            Assert.AreEqual(res.LoginResponse.backup_code, serverresponse.backup_code);
            Assert.AreEqual(res.LoginResponse.expires_in, serverresponse.expires_in);
            Assert.AreEqual(res.LoginResponse.mfa_code, serverresponse.mfa_code);
            Assert.AreEqual(res.LoginResponse.refresh_token, serverresponse.refresh_token);
            Assert.AreEqual(res.LoginResponse.scope, serverresponse.scope);
            Assert.AreEqual(res.LoginResponse.token_type, serverresponse.token_type);
        }

        [TestMethod]
        public void TestLoginWithMFA()
        {
            var serverresponse = new OAuthLoginMFARes { mfa_required = true, mfa_type = MFATypes.sms };
            HttpClientFake.PostAsJsonAsyncCallback = (u, r) =>
            {
                var msg = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
                msg.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(serverresponse), System.Text.Encoding.UTF8, "application/json");
                return Task.FromResult(msg);
            };
            var req = new OAuthLoginReq { };
            var res = RohinHoodClient.Oauth2_Token_PostAsync(req).Result;
            Assert.IsNull(res.LoginResponse);
            Assert.IsNotNull(res.MFAResponse);
            Assert.AreEqual(res.MFAResponse.mfa_required, serverresponse.mfa_required);
            Assert.AreEqual(res.MFAResponse.mfa_type, serverresponse.mfa_type);
        }
    }
}
