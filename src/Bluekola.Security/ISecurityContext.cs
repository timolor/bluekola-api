using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;

namespace Bluekola.Security
{
    public interface ISecurityContext
    {
        User User { get; }

        bool IsAdministrator { get; }
    }
}