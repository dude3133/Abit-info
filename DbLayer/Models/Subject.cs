using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public class Subject : BaseEntity
    {
        public Subject()
        {
            Specialities = new List<Speciality>();
            Specialities1 = new List<Speciality>();
            Specialities2 = new List<Speciality>();
            TestResults = new List<TestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
        public virtual ICollection<Speciality> Specialities1 { get; set; }
        public virtual ICollection<Speciality> Specialities2 { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
