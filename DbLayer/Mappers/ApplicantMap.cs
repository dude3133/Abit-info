using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class ApplicantMap : EntityTypeConfiguration<Applicant>
    {
        public ApplicantMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Name)
                .HasMaxLength(30);

            this.Property(t => t.Surname)
                .HasMaxLength(30);

            this.Property(t => t.Email)
                .HasMaxLength(256);

            this.Property(t => t.Image)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Applicants");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.Banned).HasColumnName("Banned");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.Birthdate).HasColumnName("Birthdate");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            this.Property(t => t.Suspended).HasColumnName("Suspended");
            this.Property(t => t.Sex).HasColumnName("Sex");

            // Relationships
            this.HasMany(t => t.Specialities)
                .WithMany(t => t.Applicants)
                .Map(m =>
                    {
                        m.ToTable("ApplicantSpeciality");
                        m.MapLeftKey("ApplicantId");
                        m.MapRightKey("SpecialityId");
                    });

            this.HasMany(t => t.Roles)
                .WithMany(t => t.Applicants)
                .Map(m =>
                    {
                        m.ToTable("ApplicantsRoles");
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                    });


        }
    }
}
