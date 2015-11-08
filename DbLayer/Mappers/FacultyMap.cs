using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class FacultyMap : EntityTypeConfiguration<Faculty>
    {
        public FacultyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Faculties");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UniversityId).HasColumnName("UniversityId");

            // Relationships
            this.HasRequired(t => t.University)
                .WithMany(t => t.Faculties)
                .HasForeignKey(d => d.UniversityId);

        }
    }
}
