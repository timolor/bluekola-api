using System;

namespace Bluekola.Security.Auth
{
    public interface ITokenBuilder
    {
        string Build(string userId, string[] roles, DateTime expireDate);
    }
}