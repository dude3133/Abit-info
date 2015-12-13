using DbLayer.Models;
using Microsoft.AspNet.Identity;

namespace DbLayer.Configurations
{
    class AbitInfoUserManager:UserManager<AbitInfoIdentityUser>
    {
        public AbitInfoUserManager(IUserStore<AbitInfoIdentityUser> userStore)
            : base(userStore)
        {
            //UserValidator = new UserValidator<User>(userManager)
            //{
            //    AllowOnlyAlphanumericUserNames = true,
            //    RequireUniqueEmail = true
            //};

            //PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = false,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};
        }
    }
}
