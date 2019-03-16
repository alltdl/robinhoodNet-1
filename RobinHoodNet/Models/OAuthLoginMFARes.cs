namespace RobinHoodNet.Models
{
    public class OAuthLoginMFARes
    {
        public bool mfa_required { get; set; }
        public MFATypes mfa_type { get; set; }
    }
}