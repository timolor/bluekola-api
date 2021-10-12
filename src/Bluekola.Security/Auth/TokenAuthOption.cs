using System;
using Microsoft.IdentityModel.Tokens;

namespace Bluekola.Security.Auth
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "BluekolaAudience";
        public static string Issuer { get; } = "BluekolaIssuer";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(30);
        public static string TokenType { get; } = "Bearer"; 
    }
}
