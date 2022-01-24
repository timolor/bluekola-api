using System;
using Bluekola.Data.Model.Common;

namespace Bluekola.Data.Model.Entities
{
    public class Gallery : BaseEntity
    {
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(1);
    }
}