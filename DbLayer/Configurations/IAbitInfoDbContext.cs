using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using DbLayer.Models;

namespace DbLayer.Configurations
{
    public interface IAbitInfoDbContext : IDisposable
    {
        IDbSet<Applicant> Applicants { get; set; }
        IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        IDbSet<Faculty> Faculties { get; set; }
        IDbSet<AspNetRole> AspNetRoles { get; set; }
        IDbSet<Speciality> Specialities { get; set; }
        IDbSet<University> Universities { get; set; }
        IDbSet<Subject> Subjects { get; set; }
        IDbSet<TestResult> TestResults { get; set; }
        bool Apply(Applicant applicant, Speciality speciality);
        Task<int> SaveChangesAsync();
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void Update<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
    }
}
