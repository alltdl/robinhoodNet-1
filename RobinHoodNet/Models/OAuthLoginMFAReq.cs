namespace RobinHoodNet.Models
{
    public class OAuthLoginMFAReq : OAuthLoginReq
    {
        public string mfa_code { get; set; }
    }
}
