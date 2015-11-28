using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DbLayer.Configurations;
using DbLayer.Models;
using LogicLayer.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogicLayer
{
    public interface IAuthService
    {
        Task<AbitInfoIdentityUser> FindAsync(UserLoginInfo loginInfo);
        Task<IdentityResult> CreateAsync(AbitInfoIdentityUser user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);

        Task<IdentityResult> RegisterUser(RegisterUserBindingModel registerUserModel);
        Task<AbitInfoIdentityUser> FindUser(string userName, string password);
        Task<ClaimsIdentity> CreateIdentity(AbitInfoIdentityUser user, string authenticationType);
    }

    public class AuthService : IAuthService
    {
        private readonly IAbitInfoIdentityProvider _identityProvider;

        public AuthService(IAbitInfoIdentityProvider identityProvider)
        {
            _identityProvider = identityProvider;
        }

        public async Task<AbitInfoIdentityUser> FindAsync(UserLoginInfo loginInfo)
        {
            using (IdentityDbContext<AbitInfoIdentityUser> context = _identityProvider.Context)
            {
                UserManager<AbitInfoIdentityUser> userManager =
                    _identityProvider.GetUserManager(context);
                AbitInfoIdentityUser user = await userManager.FindAsync(loginInfo);
                return user;
            }
        }

        public async Task<IdentityResult> CreateAsync(AbitInfoIdentityUser user)
        {
            using (IdentityDbContext<AbitInfoIdentityUser> context = _identityProvider.Context)
            {
                UserManager<AbitInfoIdentityUser> userManager =
                    _identityProvider.GetUserManager(context);
                var result = await userManager.CreateAsync(user);
                return result;
            }
        }


        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            using (IdentityDbContext<AbitInfoIdentityUser> context = _identityProvider.Context)
            {
                UserManager<AbitInfoIdentityUser> userManager =
                    _identityProvider.GetUserManager(context);
                var result = await userManager.AddLoginAsync(userId, login);
                return result;
            }
        }

        public async Task<IdentityResult> RegisterUser(RegisterUserBindingModel registerUserModel)
        {
            AbitInfoIdentityUser user = new AbitInfoIdentityUser
            {
                UserName = registerUserModel.Username,
                CreationTime = DateTime.UtcNow,
                Email = registerUserModel.Email,
                EmailConfirmed = true,
                Banned = false
            };

            using (IdentityDbContext<AbitInfoIdentityUser> context = _identityProvider.Context)
            {
                UserManager<AbitInfoIdentityUser> userManager =
                    _identityProvider.GetUserManager(context);

                IdentityResult result = await userManager.
                    CreateAsync(user, registerUserModel.Password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
                return result;
            }
        }

        public async Task<AbitInfoIdentityUser> FindUser(string userName, string password)
        {
            using (IdentityDbContext<AbitInfoIdentityUser> context = _identityProvider.Context)
            {
                UserManager<AbitInfoIdentityUser> userManager =
                    _identityProvider.GetUserManager(context);

                AbitInfoIdentityUser user = await userManager.FindAsync(userName, password);
                return user;
            }
        }

        public async Task<ClaimsIdentity> CreateIdentity(
            AbitInfoIdentityUser user, string authenticationType)
        {
            using (IdentityDbContext<AbitInfoIdentityUser> context = _identityProvider.Context)
            {
                var userManager = _identityProvider.GetUserManager(context);
                return await userManager.CreateIdentityAsync(user, authenticationType);
            }
        }


    }
}
