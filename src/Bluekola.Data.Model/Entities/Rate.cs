using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Bluekola.Data.Model.Common;

namespace Bluekola.Data.Model.Entities
{
    public class Rate : AuditableBaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public int ServiceId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember] 
        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; }
    }
}