using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DbLayer.Models
{
    public class BaseEntity
    {
        public BaseEntity() 
        {
            State = EntityState.Unchanged;
        }

        [NotMapped]
        public EntityState State { get; set; }
    }
}
