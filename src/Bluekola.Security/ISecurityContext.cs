using Bluekola.Data.Model;

namespace Bluekola.Security
{
    public interface ISecurityContext
    {
        User User { get; }

        bool IsAdministrator { get; }
    }
}