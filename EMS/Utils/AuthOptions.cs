using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Utils
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // token publisher
        public const string AUDIENCE = "MyAuthClient"; // tocken client
        const string KEY = "mysupersecret_secretkey!123";   // secure key
        public const int LIFETIME = 1; // token lifetime - 1 minute
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
