using System.Collections.Generic;

namespace DbLayer.Models
{
    public class Speciality : BaseEntity
    {
        public Speciality()
        {
            this.Applicants = new List<Applicant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StateOrder { get; set; }
        public int LicencedVolume { get; set; }
        public SpecialityType Type { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }

    public enum SpecialityType
    {
        Bachelor=1,
        Master
    }
}
