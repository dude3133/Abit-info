using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;

namespace DbLayer.Configurations
{
    class AbitInfoIdentityContext:IdentityDbContext<AbitInfoIdentityUser>
    {
        public AbitInfoIdentityContext()
            : base("Somee", throwIfV1Schema: false)
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
