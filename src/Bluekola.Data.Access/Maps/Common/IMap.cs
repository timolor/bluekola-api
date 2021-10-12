using Microsoft.EntityFrameworkCore;

namespace Bluekola.Data.Access.Maps.Common
{
    public interface IMap
    {
        void Visit(ModelBuilder builder);
    }
}