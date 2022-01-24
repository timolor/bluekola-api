using Bluekola.Data.Access.Maps.Common;
using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bluekola.Data.Access.Maps.Main
{
    public class ServiceMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Service>()
                .ToTable("Services")
                .HasKey(x => x.Id);
        }
    }
}