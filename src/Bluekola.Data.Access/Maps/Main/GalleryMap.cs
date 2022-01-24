using Bluekola.Data.Access.Maps.Common;
using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bluekola.Data.Access.Maps.Main
{
    public class GalleryMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Gallery>()
                .ToTable("Galleries")
                .HasKey(x => x.Id);
        }
    }
}