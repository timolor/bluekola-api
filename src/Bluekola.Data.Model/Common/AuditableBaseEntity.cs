using System;
using System.ComponentModel.DataAnnotations;

namespace Bluekola.Data.Model.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}