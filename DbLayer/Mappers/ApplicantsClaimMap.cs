using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class ApplicantsClaimMap : EntityTypeConfiguration<ApplicantsClaim>
    {
        public ApplicantsClaimMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("ApplicantsClaims");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ClaimType).HasColumnName("ClaimType");
            this.Property(t => t.ClaimValue).HasColumnName("ClaimValue");

            // Relationships
            this.HasRequired(t => t.Applicant)
                .WithMany(t => t.ApplicantsClaims)
                .HasForeignKey(d => d.UserId);

        }
    }
}
