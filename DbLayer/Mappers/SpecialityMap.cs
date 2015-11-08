using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class SpecialityMap : EntityTypeConfiguration<Speciality>
    {
        public SpecialityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Specialities");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StateOrder).HasColumnName("StateOrder");
            this.Property(t => t.LicencedVolume).HasColumnName("LicencedVolume");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.FacultyId).HasColumnName("FacultyId");

            // Relationships
            this.HasRequired(t => t.Faculty)
                .WithMany(t => t.Specialities)
                .HasForeignKey(d => d.FacultyId);

        }
    }
}
