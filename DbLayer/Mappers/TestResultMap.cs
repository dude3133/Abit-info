using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class TestResultMap : EntityTypeConfiguration<TestResult>
    {
        public TestResultMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.ApplicantId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("TestResults");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Points).HasColumnName("Points");
            Property(t => t.ApplicantId).HasColumnName("ApplicantId");
            Property(t => t.SubjectId).HasColumnName("SubjectId");

            // Relationships
            HasRequired(t => t.Applicant)
                .WithMany(t => t.TestResults)
                .HasForeignKey(d => d.ApplicantId);
            HasRequired(t => t.Subject)
                .WithMany(t => t.TestResults)
                .HasForeignKey(d => d.SubjectId);

        }
    }
}
