using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class ApplicantForSpeciality
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Banned { get; set; }
        public string Image { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Suspended { get; set; }
        public bool? Sex { get; set; }
        public int Result1 { get; set; }
        public int Result2 { get; set; }
        public int Result3 { get; set; }

    }
}
