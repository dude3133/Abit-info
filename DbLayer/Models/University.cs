using System.Collections.Generic;

namespace DbLayer.Models
{
    public class University : BaseEntity
    {
        public University()
        {
            this.Faculties = new List<Faculty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
