using Bluekola.Data.Access.Maps.Common;
using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bluekola.Data.Access.Maps.Main
{
    public class RoleMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(x => x.Id);
        }
    }
}