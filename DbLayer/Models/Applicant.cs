using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public class Applicant : BaseEntity
    {
        public Applicant()
        {
            AspNetUserClaims = new List<AspNetUserClaim>();
            AspNetUserLogins = new List<AspNetUserLogin>();
            TestResults = new List<TestResult>();
            Specialities = new List<Speciality>();
            AspNetRoles = new List<AspNetRole>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Banned { get; set; }
        public string Image { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool? Suspended { get; set; }
        public bool? Sex { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
