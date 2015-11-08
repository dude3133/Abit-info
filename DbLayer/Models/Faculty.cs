using System.Collections.Generic;

namespace DbLayer.Models
{
    public class Faculty : BaseEntity
    {
        public Faculty()
        {
            this.Specialities = new List<Speciality>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
    }
}
