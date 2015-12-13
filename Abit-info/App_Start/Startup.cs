using System;
using System.Web.Http;
using System.Web.Http.Routing;
using AbitInfo;
using AbitInfo.Models;
using DbLayer.Configurations;
using LogicLayer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Startup))]

namespace AbitInfo
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            UnityConfig.RegisterComponents(app);
            app.UseWebApi(RegisterHttpConfiguration());
            ConfigureOAuth(app);
        }
        public static HttpConfiguration RegisterHttpConfiguration()
        {
            HttpRoute route = new HttpRoute("");
            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(UnityConfig.Container),
                Routes = { { "GetUserByNameRoute", route } }
            };
            WebApiConfig.Register(config);
            return config;
        }
        public static void ConfigureOAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AbitInfoOAuthProvider(new AuthService(UnityConfig.Container.Resolve<IAbitInfoIdentityProvider>())),//UnityConfig.Container.Resolve<IAuthService>()),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
