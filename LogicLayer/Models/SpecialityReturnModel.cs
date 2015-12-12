using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;

namespace LogicLayer.Models
{
    public class SpecialityReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateOrder { get; set; }
        public int LicencedVolume { get; set; }
        public SpecialityType Type { get; set; }
        public int FacultyId { get; set; }
        public TruncatedFaculty Faculty { get; set; }
        public ICollection<TruncatedApplicant> Applicants { get; set; }
        public ICollection<TruncatedSubject> Subjects { get; set; }

    }
}
