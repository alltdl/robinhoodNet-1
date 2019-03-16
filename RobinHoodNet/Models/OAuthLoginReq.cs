namespace RobinHoodNet.Models
{
    public class OAuthLoginReq
    {
        public string client_id { get; set; }
        public string device_token { get; set; }
        public int expires_in { get; set; } = 86400;
        public string grant_type { get; set; } = "password";
        public string password { get; set; }
        public string scope { get; set; } = "internal";
        public string username { get; set; }
    }
}
