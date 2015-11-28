using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public class Speciality : BaseEntity
    {
        public Speciality()
        {
            Applicants = new List<Applicant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StateOrder { get; set; }
        public int LicencedVolume { get; set; }
        public int Type { get; set; }
        public int FacultyId { get; set; }
        public int Subject1 { get; set; }
        public int Subject2 { get; set; }
        public int? Subject3 { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Subject Subject4 { get; set; }
        public virtual Subject Subject5 { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
