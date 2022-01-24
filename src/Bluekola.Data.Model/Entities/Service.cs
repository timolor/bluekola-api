using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Bluekola.Data.Model.Common;

namespace Bluekola.Data.Model.Entities
{
    public class Service : AuditableBaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        

        [Column(TypeName = "decimal(2,2)")]
        public decimal Rating { get; set; }
        public string Gallery { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
        public string ServiceType { get; set; }
        public string Tags { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public  virtual User User { get; set; }
    }
}