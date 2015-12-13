using System.Data.Entity;
using DbLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DbLayer.Configurations
{
    public class AbitInfoIdentityContext:IdentityDbContext<AbitInfoIdentityUser>
    {
        public AbitInfoIdentityContext()
            : base("Main", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AbitInfoIdentityUser>().ToTable("Applicants");
        }
    }
}
