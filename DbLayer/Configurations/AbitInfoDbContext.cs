using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DbLayer.Mappers;
using DbLayer.Models;

namespace DbLayer.Configurations
{
    public class AbitInfoDbContext : DbContext, IAbitInfoDbContext
    {
        static AbitInfoDbContext()
        {
            //Database.SetInitializer<AbitInfoDbContext>(new AbitInfoDbInitializer());
        }

        public AbitInfoDbContext()
            : base("Name=Somee")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Applicant> Applicants { get; set; }
        public IDbSet<ApplicantsClaim> ApplicantsClaims { get; set; }
        public IDbSet<ApplicantsLogin> ApplicantsLogins { get; set; }
        public IDbSet<Faculty> Faculties { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Speciality> Specialities { get; set; }
        public IDbSet<University> Universities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicantMap());
            modelBuilder.Configurations.Add(new ApplicantsClaimMap());
            modelBuilder.Configurations.Add(new ApplicantsLoginMap());
            modelBuilder.Configurations.Add(new FacultyMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SpecialityMap());
            modelBuilder.Configurations.Add(new UniversityMap());
        }
        public void Update<T>(T entity) where T : BaseEntity
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            Set<T>().AddRange(entities);
        }

        private void SetStates()
        {
            foreach (var dbEntry in ChangeTracker.Entries<BaseEntity>())
            {
                dbEntry.State = dbEntry.Entity.State;
            }
        }
        private void RemoveStates()
        {
            foreach (var dbEntry in ChangeTracker.Entries<BaseEntity>())
            {
                dbEntry.Entity.State = EntityState.Unchanged;
            }
        }

        public override int SaveChanges()
        {
            SetStates();
            int result = base.SaveChanges();
            RemoveStates();
            return result;
        }


        public override async Task<int> SaveChangesAsync()
        {
            SetStates();
            int result = await base.SaveChangesAsync();
            RemoveStates();
            return result;
        }
    }
}
