using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;

namespace DbLayer.Configurations
{
    public interface IAbitInfoDbContext : IDisposable
    {
        IDbSet<Applicant> Applicants { get; set; }
        IDbSet<ApplicantsClaim> ApplicantsClaims { get; set; }
        IDbSet<ApplicantsLogin> ApplicantsLogins { get; set; }
        IDbSet<Faculty> Faculties { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<Speciality> Specialities { get; set; }
        IDbSet<University> Universities { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void Update<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
    }
}
