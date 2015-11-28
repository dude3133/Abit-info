namespace DbLayer.Models
{
    public class AspNetUserClaim : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}
