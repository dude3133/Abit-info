using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class SpecialityMap : EntityTypeConfiguration<Speciality>
    {
        public SpecialityMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Specialities");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.StateOrder).HasColumnName("StateOrder");
            Property(t => t.LicencedVolume).HasColumnName("LicencedVolume");
            Property(t => t.Type).HasColumnName("Type");
            Property(t => t.FacultyId).HasColumnName("FacultyId");
            Property(t => t.Subject1).HasColumnName("Subject1");
            Property(t => t.Subject2).HasColumnName("Subject2");
            Property(t => t.Subject3).HasColumnName("Subject3");

            // Relationships
            HasRequired(t => t.Faculty)
                .WithMany(t => t.Specialities)
                .HasForeignKey(d => d.FacultyId);
            HasRequired(t => t.Subject)
                .WithMany(t => t.Specialities)
                .HasForeignKey(d => d.Subject1);
            HasRequired(t => t.Subject4)
                .WithMany(t => t.Specialities1)
                .HasForeignKey(d => d.Subject2);
            HasOptional(t => t.Subject5)
                .WithMany(t => t.Specialities2)
                .HasForeignKey(d => d.Subject3);

        }
    }
}
