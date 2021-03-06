using DbLayer.Configurations;
using DbLayer.Models;
using LogicLayer;
using LogicLayer.Mappers;
using LogicLayer.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Practices.Unity;
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
            Container.RegisterType<ITruncatedUserMapper, TruncatedUserMapper>();
            Container.RegisterType<ITruncatedApplicantMapper, TruncatedApplicantMapper>();
            Container.RegisterType<ITruncatedTestResultMapper, TruncatedTestResultMapper>();
            Container.RegisterType<ITruncatedSubjectMapper, TruncatedSubjectMapper>();
            Container.RegisterType<IApplicantForSpecialityMapper, ApplicantForSpecialityMapper>();

            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<IAuthService, AuthService>();
            Container.RegisterType<IFacultyService, FacultyService>();
            Container.RegisterType<IUniversityService, UniversityService>();
            Container.RegisterType<ISpecialityService, SpecialityService>();

            Container.RegisterType<IAbitInfoIdentityProvider, AbitInfoIdentityProvider>();
            Container.RegisterType<IAbitInfoDbContextProvider, AbitInfoDbContextProvider>();
            Container.RegisterType<IAbitInfoDbContext, AbitInfoDbContext>();

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }
    }
}