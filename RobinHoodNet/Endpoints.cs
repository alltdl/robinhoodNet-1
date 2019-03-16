using System;

namespace RobinHoodNet
{
    public static class Endpoints
    {
        public static Uri Oauth2_Token_Post = new Uri("https://api.robinhood.com/oauth2/token/");
        public static Uri User_Get = new Uri("https://api.robinhood.com/user/");
    }
}
