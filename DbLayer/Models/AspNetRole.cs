using System.Collections.Generic;

namespace DbLayer.Models
{
    public class AspNetRole : BaseEntity
    {
        public AspNetRole()
        {
            Applicants = new List<Applicant>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
