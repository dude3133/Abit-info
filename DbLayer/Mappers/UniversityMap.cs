using System.Data.Entity.ModelConfiguration;
using DbLayer.Models;

namespace DbLayer.Mappers
{
    public class UniversityMap : EntityTypeConfiguration<University>
    {
        public UniversityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Universities");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
