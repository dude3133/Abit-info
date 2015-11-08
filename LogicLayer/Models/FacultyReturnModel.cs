using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;

namespace LogicLayer.Models
{
    public class FacultyReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public virtual TruncatedUniversity University { get; set; }
        public virtual ICollection<TruncatedSpeciality> Specialities { get; set; }
    }
}
