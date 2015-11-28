using Microsoft.Practices.Unity;
using System.Web.Http;
using LogicLayer;
using LogicLayer.Mappers;
using Unity.WebApi;
using DbLayer.Configurations;
using DbLayer.Models;
using LogicLayer.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;

namespace AbitInfo
{
    public static class UnityConfig
    {
        public static UnityContainer Container { get; set; }
        public static void RegisterComponents(IAppBuilder app)
        {
            Container = new UnityContainer();

            Container.RegisterInstance<IDataProtectionProvider>(app.GetDataProtectionProvider());
            Container.RegisterType<IIdentityMessageService, EmailService>();


            Container.RegisterType<IdentityUser, AbitInfoIdentityUser>();
            Container.RegisterType<IUserStore<AbitInfoIdentityUser>, UserStore< AbitInfoIdentityUser>>();
            Container.RegisterType<IdentityDbContext<AbitInfoIdentityUser>,  AbitInfoIdentityContext>();
            Container.RegisterType<IAbitInfoIdentityProvider,  AbitInfoIdentityProvider>();


            Container.RegisterType<ITruncatedFacultyMapper, TruncatedFacultyMapper>();
            Container.RegisterType<ITruncatedUniversityMapper, TruncatedUniversityMapper>();
            Container.RegisterType<ITruncatedSpecialityMapper, TruncatedSpecialityMapper>();
            Container.RegisterType<IUniversityReturnModelMapper, UniversityReturnModelMapper>();
            Container.RegisterType<ISpecialityReturnModelMapper, SpecialityReturnModelMapper>();
            Container.RegisterType<IFacultyReturnModelMapper, FacultyReturnModelMapper>();

            Container.RegisterType<IAuthService, AuthService>();
            Container.RegisterType<IFacultyService, FacultyService>();
            Container.RegisterType<IUniversityService, UniversityService>();

            Container.RegisterType<IAbitInfoIdentityProvider, AbitInfoIdentityProvider>();
            Container.RegisterType<IAbitInfoDbContextProvider, AbitInfoDbContextProvider>();
            Container.RegisterType<IAbitInfoDbContext, AbitInfoDbContext>();

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }
    }
}