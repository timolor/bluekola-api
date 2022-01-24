using System.ComponentModel.DataAnnotations;

namespace Bluekola.Data.Model.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}