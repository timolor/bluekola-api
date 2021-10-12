using System;

namespace Bluekola.Security.Auth
{
    public interface ITokenBuilder
    {
        string Build(string phone, string[] roles, DateTime expireDate);
    }
}