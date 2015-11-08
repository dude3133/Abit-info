namespace DbLayer.Models
{
    public class ApplicantsLogin : BaseEntity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}
