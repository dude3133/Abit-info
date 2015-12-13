using System.Collections.Generic;

namespace LogicLayer.Models
{
    public class UniversityReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TruncatedFaculty> Faculties { get; set; }
    }
}
