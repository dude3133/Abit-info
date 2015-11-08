using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace DbLayer.Configurations
{
    public interface IAbitInfoIdentityProvider
    {
        IdentityDbContext<AbitInfoIdentityUser> Context { get; }
        UserManager<AbitInfoIdentityUser> GetUserManager(IdentityDbContext<AbitInfoIdentityUser> context);
    }
    public class AbitInfoIdentityProvider: IAbitInfoIdentityProvider
    {
        private readonly IIdentityMessageService _service;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public IdentityDbContext<AbitInfoIdentityUser> Context
        {
            get { return new AbitInfoIdentityContext(); }
        }

        public AbitInfoIdentityProvider(IDataProtectionProvider provider, IIdentityMessageService service)
        {
            _dataProtectionProvider = provider;
            _service = service;
        }

        public UserManager<AbitInfoIdentityUser> GetUserManager(IdentityDbContext<AbitInfoIdentityUser> context)
        {
            UserStore<AbitInfoIdentityUser> userStore = new UserStore<AbitInfoIdentityUser>(context);
            AbitInfoUserManager userManager = new AbitInfoUserManager(userStore);
            userManager.EmailService = _service;
            userManager.UserTokenProvider = new DataProtectorTokenProvider<AbitInfoIdentityUser>(
                _dataProtectionProvider.Create("ASP.NET Identity"))
		        {
			        //Code for email confirmation and reset password life time
			        TokenLifespan = TimeSpan.FromHours(6)
		        };
            return userManager;
        }
    }
}
