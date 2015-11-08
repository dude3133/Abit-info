using System.Collections.Generic;

namespace DbLayer.Models
{
    public class Role : BaseEntity
    {
        public Role()
        {
            this.Applicants = new List<Applicant>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
