//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DbLayer.Models;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security.DataProtection;

//namespace DbLayer.Configurations
//{
//    class AbitInfoIdentityContextProvider
//    {
//        public AbitInfoIdentityContextProvider()
//        {
//            //_dataProtectionProvider = app.GetDataProtectionProvider();
//        }
//        public AbitInfoIdentityContext Context
//        {
//            get { return new AbitInfoIdentityContext(); }
//        }

//        private IDataProtectionProvider _dataProtectionProvider;
//        public UserManager<AbitInfoIdentityUser> GetUserManager(IdentityDbContext<AbitInfoIdentityUser> context)
//        {
//            UserStore<AbitInfoIdentityUser> userStore = new UserStore<AbitInfoIdentityUser>(context);
//            AbitInfoUserManager userManager = new AbitInfoUserManager(userStore);
//            userManager.UserTokenProvider = new DataProtectorTokenProvider<AbitInfoIdentityUser>(
//                _dataProtectionProvider.Create("ASP.NET Identity"))
//            {
//                //Code for email confirmation and reset password life time
//                TokenLifespan = TimeSpan.FromHours(6)
//            };
//            return userManager;
//        }
//    }
//}
