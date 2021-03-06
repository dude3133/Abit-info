using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class FacultyMap : EntityTypeConfiguration<Faculty>
    {
        public FacultyMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Faculties");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.UniversityId).HasColumnName("UniversityId");

            // Relationships
            HasRequired(t => t.University)
                .WithMany(t => t.Faculties)
                .HasForeignKey(d => d.UniversityId);

        }
    }
}
