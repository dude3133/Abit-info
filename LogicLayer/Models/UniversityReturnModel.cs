using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class UniversityReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TruncatedFaculty> Faculties { get; set; }
    }
}
