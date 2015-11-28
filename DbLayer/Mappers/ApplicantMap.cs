using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class ApplicantMap : EntityTypeConfiguration<Applicant>
    {
        public ApplicantMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.Name)
                .HasMaxLength(30);

            Property(t => t.Surname)
                .HasMaxLength(30);

            Property(t => t.Email)
                .HasMaxLength(256);

            Property(t => t.Image)
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("Applicants");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Surname).HasColumnName("Surname");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            Property(t => t.Banned).HasColumnName("Banned");
            Property(t => t.Image).HasColumnName("Image");
            Property(t => t.CreationTime).HasColumnName("CreationTime");
            Property(t => t.Birthdate).HasColumnName("Birthdate");
            Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            Property(t => t.Suspended).HasColumnName("Suspended");
            Property(t => t.Sex).HasColumnName("Sex");

            // Relationships
            HasMany(t => t.Specialities)
                .WithMany(t => t.Applicants)
                .Map(m =>
                    {
                        m.ToTable("ApplicantSpeciality");
                        m.MapLeftKey("ApplicantId");
                        m.MapRightKey("SpecialityId");
                    });

            HasMany(t => t.AspNetRoles)
                .WithMany(t => t.Applicants)
                .Map(m =>
                    {
                        m.ToTable("AspNetUserRoles");
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                    });


        }
    }
}
