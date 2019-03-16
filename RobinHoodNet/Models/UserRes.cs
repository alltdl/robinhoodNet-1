using System;

namespace RobinHoodNet.Models
{
    public class UserRes
    {
        public Uri additional_info { get; set; }
        public Uri basic_info { get; set; }
        public DateTimeOffset created_at { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public Uri employment { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Guid id { get; set; }
        public Uri id_info { get; set; }
        public Uri international_info { get; set; }
        public Uri investment_profile { get; set; }  
        public Uri url { get; set; }
        public string username { get; set; } 
    }
}
