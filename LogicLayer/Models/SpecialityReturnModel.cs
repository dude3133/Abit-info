using System.Collections.Generic;
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
        public ICollection<Applicant> Applicants { get; set; }
    }
}
