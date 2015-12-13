namespace DbLayer.Models
{
    public class TestResult : BaseEntity
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string ApplicantId { get; set; }
        public int SubjectId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
