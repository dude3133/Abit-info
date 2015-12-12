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
            : base("Name=Main")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Applicant> Applicants { get; set; }
        public IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public IDbSet<Faculty> Faculties { get; set; }
        public IDbSet<AspNetRole> AspNetRoles { get; set; }
        public IDbSet<Speciality> Specialities { get; set; }
        public IDbSet<University> Universities { get; set; }
        public IDbSet<Subject> Subjects { get; set; }
        public IDbSet<TestResult> TestResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicantMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new FacultyMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new SpecialityMap());
            modelBuilder.Configurations.Add(new UniversityMap());
        }

        public bool Apply(Applicant applicant, Speciality speciality)
        {
            var x = Database.SqlQuery<int>("sp_apply", applicant.Id, speciality.Id);
            return true;
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
